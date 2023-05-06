using FalconOne.API;
using FalconOne.API.AuthenticationConfig;
using FalconOne.API.AuthorizationConfig;
using FalconOne.API.DatabaseConfig;
using FalconOne.API.DependencyConfig;
using FalconOne.API.Filters;
using FalconOne.API.SwaggerConfig;
using FalconOne.DAL;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

DependencyConfig.Configure(builder);

AuthenticationConfig.Configure(builder);

SwaggerConfig.Configure(builder);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactAppOrigin",
    builder =>
    {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true)
        .WithOrigins("http://localhost:3000", "https://falcone-one.web.app", "https://localhost:3000");
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


builder.Services.AddDbContext<FalconOneContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var providerBuilder = builder.Services.BuildServiceProvider();

AuthorizationConfig.Configure(builder, providerBuilder);

var app = builder.Build();

DatabaseConfig.Configure(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o => o.DefaultModelsExpandDepth(-1));
}
app.UseCors("ReactAppOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
