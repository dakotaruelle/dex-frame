using System.Collections.Generic;
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
      var warFrames = new List<Warframe>
            {
              new Warframe
              {
                Name = "Ash"
              },
              new Warframe
              {
                Name = "Ember"
              }
            };

      return warFrames;
    }
  }
}
