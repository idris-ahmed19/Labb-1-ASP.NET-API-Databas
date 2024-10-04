using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos
{
	public class MenuRepository : IMenuRepository
	{
		private readonly RestaurantContext _context;
		public MenuRepository(RestaurantContext context)
		{
			_context = context;
		}
		public async Task AddMenuAsync(Menu menu)
		{
			_context.Menus.Add(menu);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteMenuAsync(int menuId)
		{
			var removeMenu = await _context.Menus.FindAsync(menuId);
			if (removeMenu != null)
			{
				_context.Menus.Remove(removeMenu);
			}
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Menu>> GetAllMenusAsync()
		{
			var menuList = await _context.Menus.ToListAsync();
			return menuList;
		}

		public async Task<Menu> GetMenuByIdAsync(int menuId)
		{
			var menuGot = await _context.Menus.FindAsync(menuId);
			return menuGot;
		}

		public async Task UpdateMenuAsync(Menu menu)
		{
			_context.Menus.Update(menu);
			await _context.SaveChangesAsync();
		}
	}
}
