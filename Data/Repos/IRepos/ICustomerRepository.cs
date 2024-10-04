using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos
{
	public interface ICustomerRepository
	{
		Task<IEnumerable<Customer>> GetAllCustomersAsync();
		Task<Customer> GetCustomerByIdAsync(int customerId);

		Task AddCustomerAsync(Customer customer);
		Task UpdateCustomerAsync(Customer customer);
		Task DeleteCustomerAsync(int customerId);
	}
}
