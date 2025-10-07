using Microsoft.AspNetCore.Mvc;
namespace AuthorPage.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(); // serves Views/Home/Index.cshtml
    }
}
