using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
  [ApiController]
  [Route("warframes")]
  public class WarframesController : ControllerBase
  {
    private readonly ILogger<WarframesController> _logger;

    public WarframesController(ILogger<WarframesController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Warframe> Get()
    {
      var warframes = new List<Warframe>();

      using (var connection = new SqlConnection("Server=localhost\\SqlExpress; Database=FrameDex; Trusted_connection=true"))
      {
        string getWarframesSql = @"
          SELECT * FROM dbo.warframe
        ";

        warframes = connection.Query<Warframe>(getWarframesSql).ToList();
      }

      return warframes;
    }
  }
}
