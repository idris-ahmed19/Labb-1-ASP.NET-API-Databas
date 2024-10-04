using Labb_1_ASP.NET_API___Databas.Data;
using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Models.DTOs;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Labb_1_ASP.NET_API___Databas.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}
		public async Task AddCustomerAsync(CustomerDTO customer)
		{
			var newCustomer = new Customer
			{
				Name = customer.Name,
				Email = customer.Email
			};
			await _customerRepository.AddCustomerAsync(newCustomer);
		}

		public async Task DeleteCustomerAsync(int customerId)
		{
			await _customerRepository.DeleteCustomerAsync(customerId);
		}

		public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
		{
			var listOfCustomers = await _customerRepository.GetAllCustomersAsync();
			return listOfCustomers.Select(x => new CustomerDTO
			{
				CustomerId = x.Id,
				Name = x.Name,
				Email = x.Email

			}).ToList();
		}

		public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
		{
			var customerGot = await _customerRepository.GetCustomerByIdAsync(customerId);
			if (customerGot == null)
			{
				return null;
			}

			return new CustomerDTO
			{
				CustomerId = customerGot.Id,
				Name = customerGot.Name,
				Email = customerGot.Email

			};
		}

		public async Task UpdateCustomerAsync(CustomerDTO customer, int customerId)
		{
			var updateCustomer = await _customerRepository.GetCustomerByIdAsync(customerId);

			updateCustomer.Name = customer.Name;
			updateCustomer.Email = customer.Email;
			await _customerRepository.UpdateCustomerAsync(updateCustomer);
		}
	}
}

