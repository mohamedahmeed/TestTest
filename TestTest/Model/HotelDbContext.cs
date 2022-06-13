using Microsoft.EntityFrameworkCore;
using TestTest.Controller;
using TestTest.Model;

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
        public DbSet<Rooms> Rooms { get; set; }


    }
}
