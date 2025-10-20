using AuthorPage.Models;
using AuthorPage.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorPage.Services;

public class DataService : IDataService
{
    private readonly ApplicationDbContext _context;

    public DataService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Books
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _context.Books.OrderBy(b => b.DisplayOrder).ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> CreateBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

    // Projects
    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects.OrderBy(p => p.DisplayOrder).ToListAsync();
    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        project.LastUpdated = DateTime.Now;
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> UpdateProjectAsync(Project project)
    {
        project.LastUpdated = DateTime.Now;
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task DeleteProjectAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }

    // Chapters
    public async Task<List<Chapter>> GetAllChaptersAsync()
    {
        return await _context.Chapters.OrderBy(c => c.DisplayOrder).ToListAsync();
    }

    public async Task<List<Chapter>> GetPublishedChaptersAsync()
    {
        return await _context.Chapters
            .Where(c => c.IsPublished)
            .OrderBy(c => c.DisplayOrder)
            .ToListAsync();
    }

    public async Task<Chapter?> GetChapterByIdAsync(int id)
    {
        return await _context.Chapters.FindAsync(id);
    }

    public async Task<Chapter?> GetChapterBySlugAsync(string slug)
    {
        return await _context.Chapters.FirstOrDefaultAsync(c => c.Slug == slug);
    }

    public async Task<Chapter> CreateChapterAsync(Chapter chapter)
    {
        chapter.CreatedDate = DateTime.Now;
        chapter.LastModified = DateTime.Now;
        _context.Chapters.Add(chapter);
        await _context.SaveChangesAsync();
        return chapter;
    }

    public async Task<Chapter> UpdateChapterAsync(Chapter chapter)
    {
        chapter.LastModified = DateTime.Now;
        _context.Chapters.Update(chapter);
        await _context.SaveChangesAsync();
        return chapter;
    }

    public async Task DeleteChapterAsync(int id)
    {
        var chapter = await _context.Chapters.FindAsync(id);
        if (chapter != null)
        {
            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();
        }
    }

    // Site Content
    public async Task<SiteContent?> GetSiteContentByKeyAsync(string key)
    {
        return await _context.SiteContents.FirstOrDefaultAsync(sc => sc.Key == key);
    }

    public async Task<SiteContent> UpdateSiteContentAsync(SiteContent content)
    {
        content.LastModified = DateTime.Now;
        var existing = await _context.SiteContents.FirstOrDefaultAsync(sc => sc.Key == content.Key);
        
        if (existing != null)
        {
            existing.Content = content.Content;
            existing.LastModified = content.LastModified;
            _context.SiteContents.Update(existing);
        }
        else
        {
            _context.SiteContents.Add(content);
        }
        
        await _context.SaveChangesAsync();
        return content;
    }
}