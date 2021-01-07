using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebClient.Controllers
{
  public class HomeController : Controller
  {
    private IConfiguration configuration;

    public HomeController(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    public IActionResult Index()
    {
      return View(nameof(HomeController.Index), configuration["ApiProjectUrl"]);
    }

    [HttpPost]
    public IActionResult Login(string returnUrl)
    {
      return Challenge(new AuthenticationProperties
      {
        RedirectUri = returnUrl ?? "/"
      }, "oidc");
    }
  }
}
