using Microsoft.EntityFrameworkCore;
using SimpleWeb.API.Services.Product.Model;

namespace SimpleWeb.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
