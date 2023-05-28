using Microsoft.EntityFrameworkCore;
using MvcNet6.Models;

namespace MvcNet6.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Category> Categories { get; set; }
        
    }
}
