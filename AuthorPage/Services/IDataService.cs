using AuthorPage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorPage.Services
{
    public interface IDataService
    {
        // Books
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);

        // Projects
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);

        // Chapters
        Task<List<Chapter>> GetAllChaptersAsync();
        Task<List<Chapter>> GetPublishedChaptersAsync();
        Task<Chapter?> GetChapterByIdAsync(int id);
        Task<Chapter?> GetChapterBySlugAsync(string slug);
        Task<Chapter> CreateChapterAsync(Chapter chapter);
        Task<Chapter> UpdateChapterAsync(Chapter chapter);
        Task DeleteChapterAsync(int id);

        // Site Content
        Task<SiteContent?> GetSiteContentByKeyAsync(string key);
        Task<SiteContent> UpdateSiteContentAsync(SiteContent content);
    }
}