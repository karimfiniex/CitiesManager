using CitiesManager.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.WebApi.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = Guid.Parse("51C90344-B928-4F13-8C9E-35179B7CC044"),
                CityName = "New York"
            });
            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = Guid.Parse("EFAFABD5-F1A5-47C4-9984-51AACE6D2CB1"),
                CityName = "London"
            });
        }
    }
}
