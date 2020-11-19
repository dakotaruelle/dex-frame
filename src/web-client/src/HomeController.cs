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
