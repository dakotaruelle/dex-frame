using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
