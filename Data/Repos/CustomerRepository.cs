using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly RestaurantContext _context;
		public CustomerRepository(RestaurantContext context)
		{
			_context = context;
		}
		public async Task AddCustomerAsync(Customer customer)
		{
			_context.Customers.Add(customer);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCustomerAsync(int customerId)
		{
			var removeCustomer = await _context.Customers.FindAsync(customerId);
			if (removeCustomer != null)
			{
				_context.Customers.Remove(removeCustomer);
			}
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
		{
			var customerList = await _context.Customers.ToListAsync();
			return customerList;
		}

		public async Task<Customer> GetCustomerByIdAsync(int customerId)
		{
			var customerGot = await _context.Customers.FindAsync(customerId);
			return customerGot;
		}

		public async Task UpdateCustomerAsync(Customer customer)
		{
			_context.Customers.Update(customer);
			await _context.SaveChangesAsync();
		}
	}
}
