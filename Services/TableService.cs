using Labb_1_ASP.NET_API___Databas.Data;
using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Services
{
    public class TableService : ITableService
    {
        private readonly RestaurantContext _context;

        public TableService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table> GetTableByIdAsync(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public async Task<Table> AddTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return table;
        }

        public async Task<bool> UpdateTableAsync(Table table)
        {
            var existingTable = await _context.Tables.FindAsync(table.Id);
            if (existingTable == null) return false;

            existingTable.Number = table.Number;
            existingTable.Seats = table.Seats;

            _context.Tables.Update(existingTable);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTableAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return false;

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
