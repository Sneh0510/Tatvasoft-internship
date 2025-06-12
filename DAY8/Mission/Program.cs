using Mission.Entities.Context;
using Mission.Repositories.Helpers;
using Mission.Repositories.Interface;
using Mission.Repositories.IRepositories;
using Mission.Repositories;
using Mission.Services.IServices;
using Mission.Services;
using Microsoft.EntityFrameworkCore;
using Mission.Repositories.Repositories;
using Mission.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<MissionDbContext>(db =>
    db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS policy (allow all for development)
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// Swagger for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register dependencies
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IAdminUserService, AdminUserService>();
builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Optional: comment out HTTPS redirection if using HTTP locally
// app.UseHttpsRedirection();

app.UseCors("MyPolicy");  // CORS should be before controllers

app.UseAuthorization();

app.MapControllers();

app.Run();
