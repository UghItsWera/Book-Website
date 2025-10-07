using Microsoft.EntityFrameworkCore;
using AuthorPage.Models;
using System;

namespace AuthorPage.Data;

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

        // Seed initial data
        modelBuilder.Entity<Project>().HasData(
            new Project 
            { 
                Id = 1, 
                Title = "TC", 
                ShortCode = "TC", 
                ProgressPercentage = 0.5m, 
                LastUpdated = new DateTime(2025, 10, 1), 
                DisplayOrder = 1 
            },
            new Project 
            { 
                Id = 2, 
                Title = "TEH", 
                ShortCode = "TEH", 
                ProgressPercentage = 2m, 
                LastUpdated = new DateTime(2025, 10, 1), 
                DisplayOrder = 2 
            },
            new Project 
            { 
                Id = 3, 
                Title = "Title Unknown Even To Me", 
                ShortCode = "UNKNOWN", 
                ProgressPercentage = 0m, 
                LastUpdated = new DateTime(2025, 10, 1), 
                DisplayOrder = 3 
            },
            new Project 
            { 
                Id = 4, 
                Title = "YATMTM", 
                ShortCode = "YATMTM", 
                ProgressPercentage = 0m, 
                LastUpdated = new DateTime(2025, 10, 1), 
                DisplayOrder = 4 
            }
        );

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
            }
        );
    }
}