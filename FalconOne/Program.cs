using FalconOne.API.AuthenticationConfig;
using FalconOne.API.AuthorizationConfig;
using FalconOne.API.DatabaseConfig;
using FalconOne.API.DependencyConfig;
using FalconOne.API.Filters;
using FalconOne.API.SwaggerConfig;
using FalconOne.DAL;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

DependencyConfig.Configure(builder);

AuthenticationConfig.Configure(builder);

SwaggerConfig.Configure(builder);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMemoryCache(o =>
{
    o.TrackStatistics = true;
});

builder.Services.AddRateLimiter(rateLimiterOptionns =>
{
    rateLimiterOptionns.AddTokenBucketLimiter("Token", options =>
    {
        options.TokenLimit = 5;
        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 5;
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
        options.TokensPerPeriod = 1;
        options.AutoReplenishment = true;
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactAppOrigin",
    builder =>
    {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true)
        .WithOrigins("http://localhost:3000",
        "http://app.falconone.com:5173",
        "http://localhost:5173",
        "https://localhost:5173",
        "https://falcone-one.web.app",
        "https://localhost:3000");
    });
});

builder.Services.AddControllers(c =>
{
    c.Filters.Add(new AsyncActionFilter());
    c.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    c.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
    }));
});

builder.Services.AddHttpClient();

builder.Services.AddDbContext<FalconOneContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

ServiceProvider providerBuilder = builder.Services.BuildServiceProvider();

AuthorizationConfig.Configure(builder, providerBuilder);

WebApplication app = builder.Build();

DatabaseConfig.Configure(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRateLimiter();
//app.UseMiddleware<DebugAuthorizationMiddleware>();

app.UseSwagger();

app.UseSwaggerUI(o =>
{
    o.DefaultModelsExpandDepth(-1);
    o.DisplayRequestDuration();
    o.DocumentTitle = "FalconOne APIs";
});
app.UseCors("ReactAppOrigin");

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
