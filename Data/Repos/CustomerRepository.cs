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

		public async Task<IEnumerable<Customer>> GetAllAsync()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> GetByIdAsync(int id)
		{
			return await _context.Customers.FindAsync(id);
		}

		public async Task<Customer> AddAsync(Customer customer)
		{
			_context.Customers.Add(customer);
			await _context.SaveChangesAsync();
			return customer;
		}

		public async Task<bool> UpdateAsync(Customer customer)
		{
			var existingCustomer = await _context.Customers.FindAsync(customer.Id);
			if (existingCustomer == null) return false;

			existingCustomer.Name = customer.Name;
			existingCustomer.Email = customer.Email;
			existingCustomer.Phone = customer.Phone;

			_context.Customers.Update(existingCustomer);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			if (customer == null) return false;

			_context.Customers.Remove(customer);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
