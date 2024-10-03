using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos
{
	public interface IMenuItemRepository
	{
		Task<List<MenuItem>> GetAllMenuItemsAsync();
		Task<MenuItem> GetMenuItemByIdAsync(int id);
		Task<MenuItem> AddMenuItemAsync(MenuItem menuItem);
		Task<bool> UpdateMenuItemAsync(MenuItem menuItem);
		Task<bool> DeleteMenuItemAsync(int id);
	}
}
