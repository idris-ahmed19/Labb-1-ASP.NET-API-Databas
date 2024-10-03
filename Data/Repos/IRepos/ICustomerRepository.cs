using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos
{
	public interface ICustomerRepository
	{
		Task<IEnumerable<Customer>> GetAllAsync();
		Task<Customer> GetByIdAsync(int id);
		Task<Customer> AddAsync(Customer customer);
		Task<bool> UpdateAsync(Customer customer);
		Task<bool> DeleteAsync(int id);
	}
}
