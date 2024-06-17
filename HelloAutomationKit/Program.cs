using AutomationKitWebApiBase;
using Serilog;
using Serilog.Extensions.Logging;

namespace HelloAutomationKit
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var loggerFactory = new SerilogLoggerFactory(); // For later, we need a ILogger-Instance
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // The base Database of automationKit use Npgsql driver. Currently (version 2.6) this legacy settings must be set
            Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory); // This is later used in the Serilog-Configuration for Logging

            var builder = WebApplication.CreateBuilder(args);

            // Removes the standard ASP.NET Core logging and set the min. Level to Trace (The logging is later configured in Serilog)
            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            });

            // Register Serilog as Logging Provider and use the configuration from the IConfiguration system (e.g. appsettings.json)
            builder.Host.UseSerilog((context, services, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration));

            // Add base automationKit services, also Setup Authorization, Swagger UI, etc.
            WebApiBaseConfigurator.Configure(builder.Services, builder.Configuration, loggerFactory.CreateLogger<Program>());
            // only needed, if any Apps are defined
            WebApiBaseConfigurator.RegisterAppServices(builder.Services, builder.Configuration);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Setup Routing, Authorization, Swagger UI, Apps, etc.
            WebApiBaseConfigurator.Configure(app, app.Environment, builder.Configuration);

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
        }
    }
}
