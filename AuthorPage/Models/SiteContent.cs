namespace AuthorPage.Models;

public class SiteContent
{
    public int Id { get; set; }
    public string Key { get; set; } = string.Empty; // e.g., "HomeWelcome", "AboutMe"
    public string Content { get; set; } = string.Empty;
    public DateTime LastModified { get; set; }
}