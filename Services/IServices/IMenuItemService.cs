using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Services.IServices
{
	public interface IMenuItemService
	{
		Task<List<MenuItem>> GetAllMenuItemsAsync();
		Task<MenuItem> GetMenuItemByIdAsync(int id);
		Task<MenuItem> AddMenuItemAsync(MenuItem menuItem);
		Task<bool> UpdateMenuItemAsync(int id, MenuItem menuItem);
		Task<bool> DeleteMenuItemAsync(int id);
	}
}
