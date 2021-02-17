using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebClient.ViewModels;

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
      var claimsIdentity = User.Identity as ClaimsIdentity;
      var email = claimsIdentity.FindFirst("email").Value;

      var viewModel = new IndexPageViewModel
      {
        Email = email,
        UserIsAuthenticated = User.Identity.IsAuthenticated,
        ApiProjectUrl = configuration["ApiProjectUrl"]
      };

      return View(nameof(HomeController.Index), viewModel);
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
