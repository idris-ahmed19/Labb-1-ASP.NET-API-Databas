using Labb_1_ASP.NET_API___Databas.Models.DTOs;

namespace Labb_1_ASP.NET_API___Databas.Services.IServices
{
	public interface IMenuService
	{
		Task<IEnumerable<MenuDTO>> GetAllMenusAsync();

		Task<MenuDTO> GetMenuByIdAsync(int menuId);

		Task AddMenuAsync(MenuDTO menu);

		Task UpdateMenuAsync(MenuDTO menu, int menuId);
		Task DeleteMenuAsync(int menuId);
	}
}
