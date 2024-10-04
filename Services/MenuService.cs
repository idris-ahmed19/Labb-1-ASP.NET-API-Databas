using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Models.DTOs;
using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Services.IServices;

namespace Labb_1_ASP.NET_API___Databas.Services
{
	public class MenuService : IMenuService
	{
		private readonly IMenuRepository _menuRepository;
		public MenuService(IMenuRepository menuRepository)
		{
			_menuRepository = menuRepository;
		}
		public async Task AddMenuAsync(MenuDTO menu)
		{
			var newMenu = new Menu
			{
				DishName = menu.DishName,
				Price = menu.Price,
				Availability = menu.Availability
			};
			await _menuRepository.AddMenuAsync(newMenu);
		}

		public async Task DeleteMenuAsync(int menuId)
		{
			await _menuRepository.DeleteMenuAsync(menuId);
		}

		public async Task<IEnumerable<MenuDTO>> GetAllMenusAsync()
		{
			var listOfMenu = await _menuRepository.GetAllMenusAsync();
			return listOfMenu.Select(x => new MenuDTO
			{
				MenuId = x.Id,
				DishName=x.DishName,
				Price=x.Price,
				Availability=x.Availability
			}).ToList();
		}

		public async Task<MenuDTO> GetMenuByIdAsync(int menuId)
		{
			var menuGot = await _menuRepository.GetMenuByIdAsync(menuId);
			if (menuGot == null)
			{
				return null;
			}
			return new MenuDTO
			{
				MenuId = menuGot.Id,
				DishName = menuGot.DishName,
				Price = menuGot.Price,
				Availability = menuGot.Availability
			};
		}

		public async Task UpdateMenuAsync(MenuDTO menu, int menuId)
		{
			var updateMenu = await _menuRepository.GetMenuByIdAsync(menuId);
			updateMenu.DishName = menu.DishName;
			updateMenu.Price = menu.Price;
			updateMenu.Availability = menu.Availability;
			await _menuRepository.UpdateMenuAsync(updateMenu);
		}
	}
}
