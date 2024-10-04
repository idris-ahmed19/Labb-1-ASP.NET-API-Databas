using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Models.DTOs;
using Labb_1_ASP.NET_API___Databas.Services;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1_ASP.NET_API___Databas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerServices;

		public CustomerController(ICustomerService customerServices)
		{
			_customerServices = customerServices;
		}

		[HttpGet("GetAllCustomers")]
		public async Task<IActionResult> GetAllCustomers()
		{
			var customers = await _customerServices.GetAllCustomersAsync();
			return Ok(customers);
		}

		[HttpGet("GetCustomerById")]
		public async Task<IActionResult> GetCustomerById(int id)
		{
			var customer = await _customerServices.GetCustomerByIdAsync(id);
			if (customer == null) return NotFound();
			return Ok(customer);
		}

		[HttpPost("AddCustomer")]
		public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customer)
		{
			await _customerServices.AddCustomerAsync(customer);
			return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
		}

		[HttpPut("UpdateCustomer")]
		public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDTO customer)
		{
			await _customerServices.UpdateCustomerAsync(customer, id);
			return NoContent();
		}

		[HttpDelete("DeleteCustomer")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			await _customerServices.DeleteCustomerAsync(id);
			return NoContent();
		}
	}
}
