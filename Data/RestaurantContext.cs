using Labb_1_ASP.NET_API___Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Data
{
	public class RestaurantContext : DbContext
	{

		public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
		{
		}

		public DbSet<Table> Tables { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Menu> Menus { get; set; } 

		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}