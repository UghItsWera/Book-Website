namespace AuthorPage.Models;

public class Chapter
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty; // URL-friendly version
    public string Content { get; set; } = string.Empty; // HTML content
    public string Category { get; set; } = string.Empty; // e.g., "Bonus", "Cut Content", "Lore"
    public DateTime CreatedDate { get; set; }
    public DateTime LastModified { get; set; }
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }
    public string Label { get; set; } = string.Empty;
}