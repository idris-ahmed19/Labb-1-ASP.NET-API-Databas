using Labb_1_ASP.NET_API___Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Data
{
	public class RestaurantContext : DbContext
	{
		// DbSet properties for your entities
		public DbSet<Table> Tables { get; set; }
		public DbSet<Customer> Customers { get; set; }
		//public DbSet<Booking> Bookings { get; set; }
		public DbSet<MenuItem> MenuItems { get; set; } // Assuming you have a MenuItem entity

		public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
		{
		}

		//Optionally, you can override OnModelCreating to configure the model
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);

		//	// Example: configuring entity relationships, if needed
		//	modelBuilder.Entity<Bookings>()
		//		.HasOne(r => r.Table)
		//		.WithMany()
		//		.HasForeignKey(r => r.TableId)
		//		.OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes if needed

		//	modelBuilder.Entity<Bookings>()
		//		.HasOne(r => r.Customer)
		//		.WithMany()
		//		.HasForeignKey(r => r.CustomerId)
		//		.OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes if needed

		//	// Additional configurations can be done here
		//}
	}
}