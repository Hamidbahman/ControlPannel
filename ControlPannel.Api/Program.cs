using AutoMapper;
using controlpannel.application.MappingProfiles;
using controlpannel.application.Services;
using controlpannel.domain.RepositoryInterfaces;
using controlpannel.Domain.Repositories;
using controlpannel.infrastructure.Repositories;
using controlpannel.Infrastructure.Repositories;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Repositories;
using ControlPannel.Infrastructure.Data;
using ControlPannel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<SecurityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// ✅ Register Repositories
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IConfigurationLockRepository, ConfigurationLockRepository>();
builder.Services.AddScoped<IConfigurationPasswordRepository, ConfigurationPasswordRepository>();
builder.Services.AddScoped<IConfigurationSessionRepository, ConfigurationSessionRepository>();
builder.Services.AddScoped<IActeeRepository, ActeeRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IApplicationPackageRepository, ApplicationPackageRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<ServiceAndMenuService>();
builder.Services.AddScoped<ConfigurationLockService>();
builder.Services.AddScoped<ConfigurationPasswordService>();
builder.Services.AddScoped<ConfigurationSessionService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
