using FalconOne.API.AuthenticationConfig;
using FalconOne.API.AuthorizationConfig;
using FalconOne.API.DatabaseConfig;
using FalconOne.API.DependencyConfig;
using FalconOne.API.Filters;
using FalconOne.API.SwaggerConfig;
using FalconOne.DAL;
using FalconOne.Middleware.Error;
using IdenticonSharp.Identicons;
using IdenticonSharp.Identicons.Defaults.GitHub;
using KE.IdenticonSharp.AspNetCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

builder.Services.AddRateLimiter(rlOptions =>
{
    rlOptions.AddTokenBucketLimiter("Token", blOptions =>
    {
        blOptions.TokenLimit = 5;
        blOptions.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        blOptions.QueueLimit = 5;
        blOptions.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
        blOptions.TokensPerPeriod = 1;
        blOptions.AutoReplenishment = true;
    });
});

builder.Services.AddIdenticonSharp<GitHubIdenticonProvider, GitHubIdenticonOptions>(options =>
{
    // Configuring parameters of default IdenticonProvider 
    options.SpriteSize = 10;
    options.Size = 256;
    options.HashAlgorithm = HashProvider.SHA512;
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

builder.Services.AddHealthChecks();

builder.Services.AddControllers(c =>
{
    c.Filters.Add(new AsyncActionFilter());
    c.Filters.Add<ApiExceptionFilterAttribute>();

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

app.UseHealthChecks("/status");

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

app.UseMiddleware<ErrorHandlerMiddleware>();

DbSeeder.Seed(app.Services);

app.Run();

