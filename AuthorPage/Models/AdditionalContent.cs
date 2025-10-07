namespace AuthorPage.Models
{
    public class AdditionalContent
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public string? Content { get; set; }   // Fixes the “Body” error in view (we’ll fix that next)
        public string? FilePath { get; set; }
    }
}