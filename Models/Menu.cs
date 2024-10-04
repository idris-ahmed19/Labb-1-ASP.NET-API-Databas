using System.ComponentModel.DataAnnotations;

namespace Labb_1_ASP.NET_API___Databas.Models
{
	public class Menu
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string DishName { get; set; }
		[Required]
		public int Price { get; set; }
		[Required]
		public bool Availability { get; set; }

	}
}
