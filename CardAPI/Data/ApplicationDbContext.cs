using API.Models;
using CardAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CardAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<CardDecoration> CardDecorations { get; set; }
    }
}