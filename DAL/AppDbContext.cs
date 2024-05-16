using Maxim.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Maxim.DAL
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
        public DbSet<Services> Services { get; set; }
    }
}
