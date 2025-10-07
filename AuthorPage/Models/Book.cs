namespace AuthorPage.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public string PurchaseLink { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }
}