using Microsoft.EntityFrameworkCore;

namespace TestTest
{
    public class HotelDbContext:DbContext
    {
        public HotelDbContext()
        {
            
        }

        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
