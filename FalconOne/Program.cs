using FalconeOne.BLL.Interfaces;
using FalconeOne.BLL.Services;
using FalconOne.DLL;
using FalconOne.DLL.Entities;
using FalconOne.DLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(c =>
{
    c.Filters.Add(new AsyncActionFilter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(FalconeOne.BLL.AutoMapperProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IRequestInformationService, RequestInformationService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<AsyncActionFilter>();
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password = new PasswordOptions
    {
        RequireDigit = true,
        RequiredLength = 8,
        RequireLowercase = true,
        RequireUppercase = true
    };
})
.AddEntityFrameworkStores<FalconOneContext>()
.AddDefaultTokenProviders();
builder.Services.AddDbContext<FalconOneContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")), ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
