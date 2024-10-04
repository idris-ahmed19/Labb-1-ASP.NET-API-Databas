using Labb_1_ASP.NET_API___Databas.Models.DTOs;
using Labb_1_ASP.NET_API___Databas.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1_ASP.NET_API___Databas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingServices;

		public BookingController(IBookingService bookingServices)
		{
			_bookingServices = bookingServices;
		}

		[HttpGet("GetAllBookings")]
		public async Task<IActionResult> GetAllBookings()
		{
			var bookings = await _bookingServices.GetAllBookingsAsync();
			return Ok(bookings);
		}

		[HttpGet("GetBookingById")]
		public async Task<IActionResult> GetBookingById(int id)
		{
			var booking = await _bookingServices.GetBookingByIdAsync(id);
			if (booking == null) return NotFound();
			return Ok(booking);
		}

		[HttpPost("AddBooking")]
		public async Task<IActionResult> AddBooking([FromBody] BookingDTO booking)
		{
			await _bookingServices.AddBookingAsync(booking);
			return CreatedAtAction(nameof(GetBookingById), new { id = booking.BookingId }, booking);
		}

		[HttpPut("UpdateBooking")]
		public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDTO booking)
		{
			await _bookingServices.UpdateBookingAsync(booking, id);
			return NoContent();
		}

		[HttpDelete("DeleteBooking")]
		public async Task<IActionResult> DeleteBooking(int id)
		{
			await _bookingServices.DeleteBookingAsync(id);
			return NoContent();
		}

		[HttpGet("available/{tableId}/{date}")]
		public async Task<IActionResult> IsTableAvailable(int tableId, DateTime date)
		{
			var isAvailable = await _bookingServices.CheckTableAvailability(tableId, date);
			return Ok(new { TableId = tableId, Date = date, IsAvailable = isAvailable });
		}
	}
}
