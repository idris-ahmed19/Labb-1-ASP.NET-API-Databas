using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllAsync();
        Task<Table> GetByIdAsync(int id);
        Task<Table> AddAsync(Table table);
        Task<bool> UpdateAsync(Table table);
        Task<bool> DeleteAsync(int id);
    }
}
