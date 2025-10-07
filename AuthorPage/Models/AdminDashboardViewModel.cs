using System.Collections.Generic;

namespace AuthorPage.Models
{
    public class AdminDashboardViewModel
    {
        public int BookCount { get; set; }
        public double AverageBookProgress { get; set; }
        public int ContentCount { get; set; }
        public AdditionalContent? LatestContent { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}