using BugTracking.DAL;
using BugTracking.Services;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddScoped<IBugTrackingService, BugTrackingService>();

            //web-app object
            var app = builder.Build();

            //Middle ware
            app.MapControllers();

            app.Run();
        }
    }
}