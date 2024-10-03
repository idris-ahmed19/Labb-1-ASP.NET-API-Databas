using System.ComponentModel.DataAnnotations;

namespace Labb_1_ASP.NET_API___Databas.Models
{
	public class Customer
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

	}
}
