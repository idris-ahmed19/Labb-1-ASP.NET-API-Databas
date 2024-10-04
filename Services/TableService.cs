using Labb_1_ASP.NET_API___Databas.Data;
using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Models.DTOs;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Services
{
	public class TableService : ITableService
	{
		private readonly ITableRepository _tableRepository;
		public TableService(ITableRepository tableRepository)
		{
			_tableRepository = tableRepository;
		}
		public async Task AddTableAsync(TableDTO table)
		{

			if (await _tableRepository.IsTableNumberExistsAsync(table.TableNumber))
			{
				throw new InvalidOperationException($"Table number {table.TableNumber} already exists.");
			}

			var newTable = new Models.Table
			{
				TableNumber = table.TableNumber,
				Capacity = table.Capacity
			};
			await _tableRepository.AddTableAsync(newTable);
		}

		public async Task DeleteTableAsync(int tableId)
		{
			await _tableRepository.DeleteTableAsync(tableId);
		}

		public async Task<IEnumerable<TableDTO>> GetAllTablesAsync()
		{
			var listOfTables = await _tableRepository.GetAllTablesAsync();
			return listOfTables.Select(x => new TableDTO
			{
				TableId = x.Id,
				TableNumber = x.TableNumber,
				Capacity = x.Capacity,
			}).ToList();
		}

		public async Task<TableDTO> GetTableByIdAsync(int tableId)
		{
			var tableGot = await _tableRepository.GetTableByIdAsync(tableId);
			if (tableGot == null)
			{
				return null;
			}

			return new TableDTO
			{
				TableId = tableId,
				TableNumber = tableGot.TableNumber,
				Capacity = tableGot.Capacity
			};
		}

		public async Task UpdateTableAsync(TableDTO table, int tableId)
		{

			var updateTable = await _tableRepository.GetTableByIdAsync(tableId);

			updateTable.TableNumber = table.TableNumber;
			updateTable.Capacity = table.Capacity;
			await _tableRepository.UpdateTableAsync(updateTable);
		}


	}
}
