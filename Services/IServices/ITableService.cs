using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Models.DTOs;

namespace Labb_1_ASP.NET_API___Databas.Services.IServices
{
	public interface ITableService
	{
		Task<IEnumerable<TableDTO>> GetAllTablesAsync();

		Task<TableDTO> GetTableByIdAsync(int tableId);

		Task AddTableAsync(TableDTO table);
		Task UpdateTableAsync(TableDTO table, int tableId);
		Task DeleteTableAsync(int tableId);
	}
}
