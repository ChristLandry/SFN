using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SFN_DATA.ENTITY;
using SFN_SERVICES.DI;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var conection = configuration["ConnectionStrings:DefaultConnection"];
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        Description = "Entrez le jeton Bearer dans le format \"Bearer {votre_jeton}\"",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
      {
          new OpenApiSecurityScheme
          {
              Reference = new OpenApiReference
              {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
              }
          },
          Array.Empty<string>()
      }

    });
});

builder.Services.AddDbContext<SFN_BDContext>(options => options.UseNpgsql(conection, c => c.MigrationsAssembly("SFN")));

InjectDepend.InjectionDependency(builder.Services);
SetupJWTServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();


static void SetupJWTServices(IServiceCollection services)
{
    

    var HostName_Port = "HostName:Port";
    string key = "525B298A-684C-4DDA-85E6-3A62B2412AD1"; //this should be same which is used while creating token    
    var issuer = HostName_Port;  //this should be same which is used while creating token

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = issuer,
          ValidAudience = issuer,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
      };

      options.Events = new JwtBearerEvents
      {
          OnAuthenticationFailed = context =>
          {
              if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
              {
                  context.Response.Headers.Add("Token-Expired", "true");
              }
              return Task.CompletedTask;
          }
      };
  });
}