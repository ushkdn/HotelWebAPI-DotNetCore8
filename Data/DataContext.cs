using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI_DotNetCore8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Hotel> Hotels{ get; set; }
    }

}
