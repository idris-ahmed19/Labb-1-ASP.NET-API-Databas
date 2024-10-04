using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos
{
	public class TableRepository : ITableRepository
	{
		private readonly RestaurantContext _context;
		public TableRepository(RestaurantContext context)
		{
			_context = context;
		}
		public async Task AddTableAsync(Table table)
		{
			_context.Tables.Add(table);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteTableAsync(int tableId)
		{
			var tableRemove = await _context.Tables.FindAsync(tableId);
			if (tableRemove != null)
			{
				_context.Tables.Remove(tableRemove);
			}
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Table>> GetAllTablesAsync()
		{
			var allTables = await _context.Tables.ToListAsync();
			return allTables;
		}

		public async Task<Table> GetTableByIdAsync(int tableId)
		{
			var tableGot = await _context.Tables.FindAsync(tableId);
			return tableGot;
		}

		public async Task<bool> IsTableNumberExistsAsync(int tableNumber)
		{
			return await _context.Tables.AnyAsync(t => t.TableNumber == tableNumber);
		}


		public async Task UpdateTableAsync(Table table)
		{
			_context.Tables.Update(table);
			await _context.SaveChangesAsync();
		}
	}
}
