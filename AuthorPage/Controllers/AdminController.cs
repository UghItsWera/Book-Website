using Microsoft.AspNetCore.Mvc;
using AuthorPage.Models;
using AuthorPage.Services;

namespace AuthorPage.Controllers;

public class AdminController : Controller
{
    private readonly IDataService _dataService;
    private readonly IConfiguration _configuration;

    public AdminController(IDataService dataService, IConfiguration configuration)
    {
        _dataService = dataService;
        _configuration = configuration;
    }

    private bool IsAuthenticated()
    {
        return HttpContext.Session.GetString("IsAdmin") == "true";
    }

    // === LOGIN ===
    public IActionResult Login()
    {
        if (IsAuthenticated())
            return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpPost]
    public IActionResult Login(string password)
    {
        var adminPassword = _configuration["AdminPassword"] ?? "changeme123";

        if (password == adminPassword)
        {
            HttpContext.Session.SetString("IsAdmin", "true");
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Error = "Invalid password";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Login));
    }

    // === DASHBOARD ===
    public async Task<IActionResult> Index()
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var books = await _dataService.GetAllBooksAsync();
        var projects = await _dataService.GetAllProjectsAsync();
        var chapters = await _dataService.GetAllChaptersAsync();

        ViewBag.BooksCount = books.Count;
        ViewBag.ProjectsCount = projects.Count;
        ViewBag.ChaptersCount = chapters.Count;

        return View();
    }

    // === BOOKS ===
    public async Task<IActionResult> Books()
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var books = await _dataService.GetAllBooksAsync();
        return View(books);
    }

    public IActionResult CreateBook()
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(Book book)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        if (ModelState.IsValid)
        {
            await _dataService.CreateBookAsync(book);
            return RedirectToAction(nameof(Books));
        }

        return View(book);
    }

    public async Task<IActionResult> EditBook(int id)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var book = await _dataService.GetBookByIdAsync(id);
        if (book == null)
            return NotFound();

        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> EditBook(Book book)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        if (ModelState.IsValid)
        {
            await _dataService.UpdateBookAsync(book);
            return RedirectToAction(nameof(Books));
        }

        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteBook(int id)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        await _dataService.DeleteBookAsync(id);
        return RedirectToAction(nameof(Books));
    }

    // === PROJECTS ===
    public async Task<IActionResult> Projects()
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var projects = await _dataService.GetAllProjectsAsync();
        return View(projects);
    }

    public IActionResult CreateProject()
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(Project project)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        if (ModelState.IsValid)
        {
            // Automatically set DisplayOrder
            var existingProjects = await _dataService.GetAllProjectsAsync();
            project.DisplayOrder = existingProjects.Count + 1;

            await _dataService.CreateProjectAsync(project);
            return RedirectToAction(nameof(Projects));
        }

        return View(project);
    }

    public async Task<IActionResult> EditProject(int id)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var project = await _dataService.GetProjectByIdAsync(id);
        if (project == null)
            return NotFound();

        return View(project);
    }

    [HttpPost]
    public async Task<IActionResult> EditProject(Project project)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        if (ModelState.IsValid)
        {
            await _dataService.UpdateProjectAsync(project);
            return RedirectToAction(nameof(Projects));
        }

        return View(project);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProject(int id)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        await _dataService.DeleteProjectAsync(id);
        return RedirectToAction(nameof(Projects));
    }

    // === CHAPTERS ===
    public async Task<IActionResult> Chapters()
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var chapters = await _dataService.GetAllChaptersAsync();
        return View(chapters);
    }

    public IActionResult CreateChapter()
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateChapter(Chapter chapter)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        if (ModelState.IsValid)
        {
            // Generate slug from title
            chapter.Slug = GenerateSlug(chapter.Title);
            await _dataService.CreateChapterAsync(chapter);
            return RedirectToAction(nameof(Chapters));
        }

        return View(chapter);
    }

    public async Task<IActionResult> EditChapter(int id)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var chapter = await _dataService.GetChapterByIdAsync(id);
        if (chapter == null)
            return NotFound();

        return View(chapter);
    }

    [HttpPost]
    public async Task<IActionResult> EditChapter(Chapter chapter)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        if (ModelState.IsValid)
        {
            // Update slug if title changed
            chapter.Slug = GenerateSlug(chapter.Title);
            await _dataService.UpdateChapterAsync(chapter);
            return RedirectToAction(nameof(Chapters));
        }

        return View(chapter);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteChapter(int id)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        await _dataService.DeleteChapterAsync(id);
        return RedirectToAction(nameof(Chapters));
    }

    // === SITE CONTENT ===
    public async Task<IActionResult> SiteContent()
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var homeWelcome = await _dataService.GetSiteContentByKeyAsync("HomeWelcome");
        var aboutMe = await _dataService.GetSiteContentByKeyAsync("AboutMe");

        ViewBag.HomeWelcome = homeWelcome?.Content ?? "";
        ViewBag.AboutMe = aboutMe?.Content ?? "";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSiteContent(string key, string content)
    {
        if (!IsAuthenticated())
            return RedirectToAction(nameof(Login));

        var siteContent = new SiteContent
        {
            Key = key,
            Content = content
        };

        await _dataService.UpdateSiteContentAsync(siteContent);
        return RedirectToAction(nameof(SiteContent));
    }

    private string GenerateSlug(string title)
    {
        return title.ToLower()
            .Replace(" ", "-")
            .Replace("'", "")
            .Replace("\"", "")
            .Replace("!", "")
            .Replace("?", "")
            .Replace(",", "")
            .Replace(".", "");
    }
}