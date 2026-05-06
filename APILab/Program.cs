using APILab.Configs;
using APILab.Customs.CustomFilters;
using APILab.Customs.CustomMiddlewares;
using APILab.Models;
using APILab.Repos;
using APILab.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
using System.Text;

namespace APILab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup()
                .LoadConfigurationFromFile("nlog.config")
                .GetCurrentClassLogger();

            try
            {
                logger.Info("Application starting...");

                var builder = WebApplication.CreateBuilder(args);

                // -------------------------------------------------------
                // NLog Register
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();


                // Global filter for all controllers 
                builder.Services.AddControllers();
                builder.Services.AddOpenApi();
                builder.Services.AddSwaggerGen();

                // Repo Services
                builder.Services.AddScoped<IStudentRepo, StudentRepo>();
                builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
                builder.Services.AddScoped<IUnitOfWork, UOW>();

                // DB Service
                builder.Services.AddDbContext<AppMainContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

                builder.Services.AddIdentity<ApplicationUser, IdentityRole>() // this set Check Cookies in the request not JWT Token
                    .AddEntityFrameworkStores<AppMainContext>()
                    .AddDefaultTokenProviders();


                // JWT Register Auth
                    builder.Services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;  
                        options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = builder.Configuration["Jwt:Issuer"],
                           ValidAudience = builder.Configuration["Jwt:Audience"],
                           IssuerSigningKey = new SymmetricSecurityKey(
                               Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                       };
                   });

                builder.Services.AddAuthorization();


                // Register The Mapster Package 
                MappingConfig.RegisterMappings();


                // Cors
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll", policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
                });
                var app = builder.Build();

                // Custom Middleware
                app.UseExceptionHandling();

                if (app.Environment.IsDevelopment())
                {
                    app.MapOpenApi();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseCors("AllowAll");
                app.UseAuthentication();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Application stopped due to an exception.");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}