using Labb_1_ASP.NET_API___Databas.Data;
using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly RestaurantContext _context;

		public CustomerService(RestaurantContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> GetCustomerByIdAsync(int id)
		{
			return await _context.Customers.FindAsync(id);
		}

		public async Task<Customer> AddCustomerAsync(Customer customer)
		{
			_context.Customers.Add(customer);
			await _context.SaveChangesAsync();
			return customer;
		}

		public async Task<bool> UpdateCustomerAsync(Customer customer)
		{
			var existingCustomer = await _context.Customers.FindAsync(customer.Id);
			if (existingCustomer == null) return false;

			existingCustomer.Name = customer.Name;
			existingCustomer.Email = customer.Email;
			existingCustomer.Phone = customer.Phone;

			_context.Customers.Update(existingCustomer);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteCustomerAsync(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			if (customer == null) return false;

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}

