using Labb_1_ASP.NET_API___Databas.Data;
using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Services
{
	public class MenuItemService : IMenuItemService
	{
		private readonly RestaurantContext _context;

		public MenuItemService(RestaurantContext context)
		{
			_context = context;
		}

		public async Task<List<MenuItem>> GetAllMenuItemsAsync()
		{
			return await _context.MenuItems.ToListAsync();
		}

		public async Task<MenuItem> GetMenuItemByIdAsync(int id)
		{
			return await _context.MenuItems.FindAsync(id);
		}

		public async Task<MenuItem> AddMenuItemAsync(MenuItem menuItem)
		{
			_context.MenuItems.Add(menuItem);
			await _context.SaveChangesAsync();
			return menuItem;
		}

		public async Task<bool> UpdateMenuItemAsync(int id, MenuItem menuItem)
		{
			var existingMenuItem = await _context.MenuItems.FindAsync(id);
			if (existingMenuItem == null) return false;

			existingMenuItem.Name = menuItem.Name;
			existingMenuItem.Price = menuItem.Price;
			existingMenuItem.IsAvailable = menuItem.IsAvailable;

			_context.MenuItems.Update(existingMenuItem);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteMenuItemAsync(int id)
		{
			var menuItem = await _context.MenuItems.FindAsync(id);
			if (menuItem == null) return false;

			_context.MenuItems.Remove(menuItem);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
