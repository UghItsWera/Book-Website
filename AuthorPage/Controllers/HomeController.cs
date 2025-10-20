using Microsoft.AspNetCore.Mvc;
namespace AuthorPage.Controllers;
using AuthorPage.Controllers;
using AuthorPage.Services;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(); // serves Views/Home/Index.cshtml
    }
    public async Task<IActionResult> AdditionalContent([FromServices] IDataService dataService)
{
    var content = await dataService.GetSiteContentByKeyAsync("AdditionalContent");
    var chapters = await dataService.GetAllChaptersAsync();
    var projects = await dataService.GetAllProjectsAsync();
    var books = await dataService.GetAllBooksAsync();

    // Group chapters by label (book/project)
    var groupedChapters = chapters
        .GroupBy(c => c.Label ?? "Unlabeled")
        .ToDictionary(g => g.Key, g => g.ToList());

    ViewBag.AdditionalContent = content?.Content ?? "";
    ViewBag.GroupedChapters = groupedChapters;
    ViewBag.Projects = projects;
    ViewBag.Books = books;

    return View();
}

}
