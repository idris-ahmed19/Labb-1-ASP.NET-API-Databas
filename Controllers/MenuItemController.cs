using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1_ASP.NET_API___Databas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuItemController : ControllerBase
	{
		private readonly IMenuItemService _menuItemService;

		public MenuItemController(IMenuItemService menuItemService)
		{
			_menuItemService = menuItemService;
		}

		// GET: api/menuitem
		[HttpGet]
		public async Task<ActionResult<List<MenuItem>>> GetAllMenuItems()
		{
			var menuItems = await _menuItemService.GetAllMenuItemsAsync();
			return Ok(menuItems);
		}

		// GET: api/menuitem/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<MenuItem>> GetMenuItemById(int id)
		{
			var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
			if (menuItem == null)
				return NotFound();

			return Ok(menuItem);
		}

		// POST: api/menuitem
		[HttpPost]
		public async Task<ActionResult<MenuItem>> AddMenuItem([FromBody] MenuItem menuItem)
		{
			var newMenuItem = await _menuItemService.AddMenuItemAsync(menuItem);
			return CreatedAtAction(nameof(GetMenuItemById), new { id = newMenuItem.Id }, newMenuItem);
		}

		// PUT: api/menuitem/{id}
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateMenuItem(int id, [FromBody] MenuItem menuItem)
		{
			var success = await _menuItemService.UpdateMenuItemAsync(id, menuItem);
			if (!success) return NotFound();

			return NoContent();
		}

		// DELETE: api/menuitem/{id}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteMenuItem(int id)
		{
			var success = await _menuItemService.DeleteMenuItemAsync(id);
			if (!success) return NotFound();

			return NoContent();
		}
	}
}
