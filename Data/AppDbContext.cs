
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<LibraryEntities> Books { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "bookss1.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(e => e.Address);

            modelBuilder.Entity<BookEntity>()
            .HasOne(e => e.Organization)
            .WithMany(o => o.Book)
            .HasForeignKey(e => e.OrganizationId);



            modelBuilder.Entity<OrganizationEntity>().HasData(
         new OrganizationEntity()
         {
             Id = 1,
             Title = "WSEI",
             Nip = "83492384",
             Regon = "13424234",
         },
         new OrganizationEntity()
         {
             Id = 2,
             Title = "Firma",
             Nip = "2498534",
             Regon = "0873439249",
         }
     ); ;



            modelBuilder.Entity<LibraryEntities>().HasData(
                new LibraryEntities()
                {
                    Id = 1,
                    Title = "Test book",
                    Author = "Michal Wojciechowski",
                    NumberOfPages = 100,
                    ISBN = 123,
                    PublicationDate = new DateTime(2023, 11, 12),
                    PublishingHouse = "Wsei"
                },
                new LibraryEntities()
                {
                    Id = 2,
                    Title = "Book 2",
                    Author = "Wojciech Michałowski",
                    NumberOfPages = 200,
                    ISBN = 321,
                    PublicationDate = new DateTime(2023, 11, 12),
                    PublishingHouse = "Agh"
                });

            modelBuilder.Entity<OrganizationEntity>()
       .OwnsOne(e => e.Address)
       .HasData(
           new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
           new { OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
       );
        }
    }
}

