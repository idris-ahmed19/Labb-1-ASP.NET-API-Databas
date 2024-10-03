using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1_ASP.NET_API___Databas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		// GET: api/customer
		[HttpGet]
		public async Task<ActionResult<List<Customer>>> GetAllCustomers()
		{
			var customers = await _customerService.GetAllCustomersAsync();
			return Ok(customers);
		}

		// GET: api/customer/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Customer>> GetCustomer(int id)
		{
			var customer = await _customerService.GetCustomerByIdAsync(id);
			if (customer == null)
			{
				return NotFound();
			}
			return Ok(customer);
		}

		// POST: api/customer
		[HttpPost]
		public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
		{
			var createdCustomer = await _customerService.AddCustomerAsync(customer);
			return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
		}

		// PUT: api/customer/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
		{
			if (id != customer.Id)
			{
				return BadRequest();
			}

			var updated = await _customerService.UpdateCustomerAsync(customer);
			if (!updated)
			{
				return NotFound();
			}

			return NoContent();
		}

		// DELETE: api/customer/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			var deleted = await _customerService.DeleteCustomerAsync(id);
			if (!deleted)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}
