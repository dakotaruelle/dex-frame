using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebClient
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
        webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
        {
          var settings = config.Build();
          var azureAppConfigurationConnection = settings.GetConnectionString("AppConfig");
          var env = hostingContext.HostingEnvironment;
          var configurationRoot = config.Sources.ElementAt(0);

          config.Sources.Clear();

          config.Add(configurationRoot);

          config.AddJsonFile("appsettings.json",
              optional: false,
              reloadOnChange: true
          );

          config.AddJsonFile($"appsettings.{env.EnvironmentName}.json",
              optional: true,
              reloadOnChange: true
          );

          config.AddAzureAppConfiguration(options =>
          {
            options.Connect(azureAppConfigurationConnection)
                .ConfigureKeyVault(options =>
                {
                  options.SetCredential(AzureCredentialProvider.GetAzureCredential(env, settings));
                });
          });

          if (env.IsDevelopment())
          {
            config.AddUserSecrets(Assembly.GetExecutingAssembly());
          }

          config.AddEnvironmentVariables();

          config.AddCommandLine(args);

        }).UseStartup<Startup>());
  }
}
