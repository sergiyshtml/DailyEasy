using DailyEasy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DailyEasy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categori> Categories { get; set; }
        public DbSet<Legging> Leggings { get; set; }
        public DbSet<LeggingColor> LeggingColors { get; set; }
        public DbSet<LeggingSize> LeggingSizes { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Legging[] leggings = new Legging[3];
            leggings[0] = new Legging { Id = 1, Name = "Легінси", CategoriID = 1, ColorID = 1, SizeID = 1, Price = 1000 };
            leggings[1] = new Legging { Id = 2, Name = "Легінси", CategoriID = 1, ColorID = 2, SizeID = 3, Price = 900 };
            leggings[2] = new Legging { Id = 3, Name = "Легінси", CategoriID = 1, ColorID = 3, SizeID = 5, Price = 800 };

            Categori[] categories = new Categori[3];
            categories[0] = new Categori { Id = 1, Name = "Push-up ефектом" };
            categories[1] = new Categori { Id = 2, Name = "Гладенькі" };
            categories[2] = new Categori { Id = 3, Name = "В рубчик" };

            LeggingSize[] leggingSizes = new LeggingSize[6];
            leggingSizes[0] = new LeggingSize { Id = 1, Size = "XS" };
            leggingSizes[1] = new LeggingSize { Id = 2, Size = "S" };
            leggingSizes[2] = new LeggingSize { Id = 3, Size = "M" };
            leggingSizes[3] = new LeggingSize { Id = 4, Size = "L" };
            leggingSizes[4] = new LeggingSize { Id = 5, Size = "XL" };
            leggingSizes[5] = new LeggingSize { Id = 6, Size = "XXL" };

            LeggingColor[] leggingColors = new LeggingColor[3];
            leggingColors[0] = new LeggingColor { Id = 1, Color = "Чорний" };
            leggingColors[1] = new LeggingColor { Id = 2, Color = "Сірий" };
            leggingColors[2] = new LeggingColor { Id = 3, Color = "Білий" };

            Photo[] photos = new Photo[3];
            photos[0] = new Photo { Id = 1, Url = "/Image/19221.970.jpg", LeggingId = 1 };
            photos[1] = new Photo { Id = 2, Url = "/Image/201957.1200x0.jpg", LeggingId = 2 };
            photos[2] = new Photo { Id = 3, Url = "/Image/bust.jpg", LeggingId = 3 };

            builder.Entity<Legging>().HasData(leggings);
            builder.Entity<Categori>().HasData(categories);
            builder.Entity<LeggingSize>().HasData(leggingSizes);
            builder.Entity<LeggingColor>().HasData(leggingColors);
            builder.Entity<Photo>().HasData(photos);
        }
    }
}

