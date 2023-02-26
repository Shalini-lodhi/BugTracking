using BugTracking.DAL;
using BugTracking.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

namespace BugTracking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //All builder
            var builder = WebApplication.CreateBuilder(args);

            //connection to Database
            builder.Services.AddDbContext<BugTrackingContext>(option =>
            {
                //connecting  DB
                option.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
            });
            //Service connection
            builder.Services.AddControllers();

            //Service Scope
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IBugTrackingService, BugTrackingService>();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("heyheyheyheyehyehey")),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            builder.Services.AddAuthorization(options => {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Roles", "Admin"));
                options.AddPolicy("User", policy => policy.RequireClaim("Roles", "User", "Admin"));
                options.AddPolicy("Member", policy => policy.RequireClaim("Roles", "Member", "Admin"));
            });
            //web-app object
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();

            //
            


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();


            //Middle ware
            app.MapControllers();

            app.Run();
        }
    }
}