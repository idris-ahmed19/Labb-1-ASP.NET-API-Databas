using Labb_1_ASP.NET_API___Databas.Models.DTOs;
using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Services.IServices
{
	public interface IBookingService
	{
		Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();

		Task<BookingDTO> GetBookingByIdAsync(int bookingId);

		Task AddBookingAsync(BookingDTO booking);
		Task UpdateBookingAsync(BookingDTO booking, int bookingId);
		Task DeleteBookingAsync(int bookingId);

		public Task<bool> CheckTableAvailability(int tableId, DateTime date);


	}
}
