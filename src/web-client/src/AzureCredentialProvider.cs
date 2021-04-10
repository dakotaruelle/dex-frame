using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WebClient
{
  internal static class AzureCredentialProvider
  {
    internal static TokenCredential GetAzureCredential(IHostEnvironment environment, IConfiguration configuration)
    {
      TokenCredential azureCredential;
      if (environment.IsDevelopment())
      {
        azureCredential = new ClientSecretCredential(
            configuration.GetValue<string>("ServicePrincipalTenantId"),
            configuration.GetValue<string>("ServicePrincipalClientId"),
            configuration.GetValue<string>("ServicePrincipalClientSecret")
        );
      }
      else
      {
        azureCredential = new DefaultAzureCredential();
      }

      return azureCredential;
    }
  }
}
