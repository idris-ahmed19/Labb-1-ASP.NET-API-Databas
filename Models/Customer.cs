using System.ComponentModel.DataAnnotations;

namespace Labb_1_ASP.NET_API___Databas.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Email { get; set; }
		public ICollection<Booking> Bookings { get; set; }


	}
}
