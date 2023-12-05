
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<LibraryEntities> Books { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "books.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryEntities>().HasData(
                new LibraryEntities() { Id = 1, Title = "Test book", Author = "Michal Wojciechowski", NumberOfPages = 100, ISBN = 123, PublicationDate = new DateTime(2023, 11, 12), PublishingHouse = "Wsei" }
            );
        }
    }
}
