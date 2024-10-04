using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos
{
	public interface ITableRepository
	{
		Task<IEnumerable<Table>> GetAllTablesAsync();

		Task<Table> GetTableByIdAsync(int tableId);

		Task AddTableAsync(Table table);
		Task UpdateTableAsync(Table table);
		Task DeleteTableAsync(int tableId);
		public Task<bool> IsTableNumberExistsAsync(int tableNumber);


	}
}
