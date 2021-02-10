using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Api.DataUpdates.Warframe;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
  [ApiController]
  [Route("warframes")]
  public class WarframesController : ControllerBase
  {
    private readonly ILogger<WarframesController> logger;
    private readonly IConfiguration configuration;

    public WarframesController(ILogger<WarframesController> logger, IConfiguration configuration)
    {
      this.logger = logger;
      this.configuration = configuration;
    }

    [HttpGet]
    public async Task<List<Warframe>> Get()
    {
      try
      {
        var warframes = new List<Warframe>();

        using (var connection = new SqlConnection(configuration["FrameDexDbConnectionString"]))
        {
          string getWarframesSql = @"
            SELECT *
            FROM dbo.Warframe
          ";

          warframes = (await connection.QueryAsync<Warframe>(getWarframesSql)).ToList();
        }

        return warframes;
      }
      catch (Exception exception)
      {
        System.Console.WriteLine(exception);
        return new List<Warframe>();
      }
    }
  }
}
