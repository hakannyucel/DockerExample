using DockerExample.Application;
using DockerExample.Persistence;
using DockerExample.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer("Bearer", options =>
          {
              options.RequireHttpsMetadata = false;
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Security"])),
                  ValidateIssuer = true,
                  ValidIssuer = builder.Configuration["JWT:Issuer"],
                  ValidateAudience = true,
                  ValidAudience = builder.Configuration["JWT:Audience"],
                  ValidateLifetime = true,
                  ClockSkew = TimeSpan.Zero,
                  RequireExpirationTime = true
              };
          });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseGlobalExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
