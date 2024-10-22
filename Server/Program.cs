using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpLogging;
using System.Net;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start Application");

            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            builder.Services.AddHttpLogging(options =>
            {
                options.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders;
            });
             

            var app = builder.Build();

            app.UseForwardedHeaders();
            app.UseHttpLogging();

           

            app.MapGet("/", () =>
            {
                Console.WriteLine("Hello ForwardedHeadersOptions!");
                return "Hello ForwardedHeadersOptions!";
            });
             

            app.Run();
        }
    }
}
