using System.Security.Claims;
using System.Threading.Tasks;
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
      var emailClaim = claimsIdentity.FindFirst("email");

      var viewModel = new IndexPageViewModel
      {
        Email = emailClaim?.Value ?? "",
        UserIsAuthenticated = claimsIdentity.IsAuthenticated,
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

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync();
      return LocalRedirect("/");
    }
  }
}
