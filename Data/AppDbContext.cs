
using Data.Entities;
using Microsoft.AspNetCore.Identity;
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
            DbPath = System.IO.Path.Join(path, "books.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //USER ADMIN 
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADMIN"
            };

            // haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");

            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });

            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });



            ////////////////////////////////////////////////////////////////
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            // Utworzenie użytkownika jako USER
            var user = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "jan@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "jan",
                NormalizedUserName = "JAN"
            };

            // Haszowanie hasła dla użytkownika
            PasswordHasher<IdentityUser> userPasswordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = userPasswordHasher.HashPassword(user, "userpassword123!@#");

            // Zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(user);

            // Przypisanie roli USER użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = user.Id
            });


            ////////////////////////////////////////////////////////////////

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

