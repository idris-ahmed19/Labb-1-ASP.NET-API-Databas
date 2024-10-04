using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Models.DTOs;

namespace Labb_1_ASP.NET_API___Databas.Services.IServices
{
	public interface ICustomerService
	{
		Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
		Task<CustomerDTO> GetCustomerByIdAsync(int customerId);

		Task AddCustomerAsync(CustomerDTO customer);
		Task UpdateCustomerAsync(CustomerDTO customer, int customerId);
		Task DeleteCustomerAsync(int customerId);
	}
}
