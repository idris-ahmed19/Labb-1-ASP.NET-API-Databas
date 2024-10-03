using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Services.IServices
{
	public interface ICustomerService
	{
		Task<IEnumerable<Customer>> GetAllCustomersAsync();
		Task<Customer> GetCustomerByIdAsync(int id);
		Task<Customer> AddCustomerAsync(Customer customer);
		Task<bool> UpdateCustomerAsync(Customer customer);
		Task<bool> DeleteCustomerAsync(int id);
	}
}
