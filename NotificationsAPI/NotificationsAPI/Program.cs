using NotificationsAPI.DB;
using NotificationsAPI.DB.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using NotificationsAPI.DB.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var cns = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<NotificationsDBContext>(options =>
{
   // options.UseSqlServer(cns);
   options.UseInMemoryDatabase(databaseName:"Notifications");
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = builder.Configuration["Jwt:Issuer"],
                      ValidAudience = builder.Configuration["Jwt:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                  };
              }
              );
builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy => {
        policy
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin()
           .WithOrigins(
               "http://localhost:3000");
    });
    opt.AddPolicy("SignalRCorsPolicy", policy => {
        policy.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials()
           .WithOrigins(
               "http://localhost:3000");
    });
});
var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    var dataContext=scope.ServiceProvider.GetRequiredService<NotificationsDBContext>();
    //Create Database
    //InMemoryDatabase
    dataContext.Database.EnsureCreated();
    //Real Database
    //dataContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
