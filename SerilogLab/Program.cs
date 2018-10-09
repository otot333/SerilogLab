using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using SerilogLab.LogHelper.Enricher;

namespace SerilogLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitializeLogger();
            CreateWebHostBuilder(args).Build().Run();
        }
        
        private static void InitializeLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithProperty("Version", "1.0")
                .Enrich.With(new ThreadIdEnricher())
                .WriteTo.ColoredConsole(
                    outputTemplate: 
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{SourceContext}] [{Level:u3}] [{Version}] {Message:lj} [{ThreadId}] {NewLine}")
                .WriteTo.RollingFile("log.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{SourceContext}][{ThreadId}][{Level:u3}] {Message:lj} {NewLine}")
                .WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri("http://localhost:9200")){
                        IndexFormat = "Request",
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
                })
                .CreateLogger();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(config => {
                    config.ClearProviders();
                })
                .UseStartup<Startup>();
        

    }
}