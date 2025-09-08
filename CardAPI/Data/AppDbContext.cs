using API.Models;
using Microsoft.EntityFrameworkCore;


namespace YourProjectNamespace.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }  // هذا يربط الكيان بقاعدة البيانات

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}