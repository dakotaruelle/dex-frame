using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(string returnUrl)
    {
      return Challenge(new AuthenticationProperties
      {
        RedirectUri = returnUrl ?? "/Home/Profile"
      }, "oidc");
    }

    public IActionResult AccessDenied()
    {
      return View();
    }

    public IActionResult Profile()
    {
      return View(User.Identity.IsAuthenticated);
    }
  }
}
