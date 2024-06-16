using CRUDyExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDyExample.Data
{
    public class MyCrudDBContext : DbContext
    {
        public MyCrudDBContext(DbContextOptions<MyCrudDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
