using FalconeOne.BLL.Services;
using FalconOne.API.AuthenticationConfig;
using FalconOne.API.AuthorizationConfig;
using FalconOne.API.DependencyConfig;
using FalconOne.API.SwaggerConfig;
using FalconOne.DLL;
using Microsoft.EntityFrameworkCore;
using Utilities.Profiles;

var builder = WebApplication.CreateBuilder(args);

DependencyConfig.Configure(builder);

AuthenticationConfig.Configure(builder);

SwaggerConfig.Configure(builder);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllers(c =>
{
    c.Filters.Add(new AsyncActionFilter());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactAppOrigin",
    builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});

builder.Services.AddDbContext<FalconOneContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")), ServiceLifetime.Transient);

var providerBuilder = builder.Services.BuildServiceProvider();

AuthorizationConfig.Configure(builder, providerBuilder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("ReactAppOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
