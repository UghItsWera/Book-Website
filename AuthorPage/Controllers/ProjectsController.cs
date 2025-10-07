using Microsoft.AspNetCore.Mvc;

public class ProjectsController : Controller
{
    public IActionResult Existing()
    {
        return View(); // serves Views/Projects/Existing.cshtml
    }

    public IActionResult Upcoming()
    {
        return View(); // serves Views/Projects/Upcoming.cshtml
    }
}