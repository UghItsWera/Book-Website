using Microsoft.AspNetCore.Mvc;

public class ContentController : Controller
{
    public IActionResult Additional()
    {
        return View(); // serves Views/Content/Additional.cshtml
    }
}