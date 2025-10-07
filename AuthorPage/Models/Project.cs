using System;
using System.ComponentModel.DataAnnotations;

namespace AuthorPage.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [StringLength(20)]
        public string? ShortCode { get; set; } // a short identifier (e.g. "BOOK1")

        public string? Description { get; set; }

        [Range(0, 100)]
        public decimal ProgressPercentage { get; set; }

        public int DisplayOrder { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? LastUpdated { get; set; } = DateTime.Now;

        public bool IsPublished { get; set; } = false;
    }
}