using Microsoft.EntityFrameworkCore;
using AuthorPage.Models;
using System;

namespace AuthorPage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<SiteContent> SiteContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed only static site content
            modelBuilder.Entity<SiteContent>().HasData(
                new SiteContent 
                { 
                    Id = 1, 
                    Key = "HomeWelcome", 
                    Content = "Everything you need to know about what I'm working on and what I have created can be found here.", 
                    LastModified = new DateTime(2025, 10, 1) 
                },
                new SiteContent 
                { 
                    Id = 2, 
                    Key = "AboutMe", 
                    Content = "Hi", 
                    LastModified = new DateTime(2025, 10, 1) 
                },
                new SiteContent 
                { 
                    Id = 3, 
                    Key = "AdditionalContent", 
                    Content = "", 
                    LastModified = new DateTime(2025, 10, 8) 
                }
            );

            // Optional: add indices or relationships if needed
            modelBuilder.Entity<Chapter>()
                        .HasIndex(c => c.Label); // helps querying by label efficiently
        }
    }
}