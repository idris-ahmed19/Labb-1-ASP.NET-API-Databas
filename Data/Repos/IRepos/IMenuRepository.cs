using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos
{
	public interface IMenuRepository
	{
		Task<IEnumerable<Menu>> GetAllMenusAsync();

		Task<Menu> GetMenuByIdAsync(int menuId);

		Task AddMenuAsync(Menu menu);

		Task UpdateMenuAsync(Menu menu);
		Task DeleteMenuAsync(int menuId);

	}
}
