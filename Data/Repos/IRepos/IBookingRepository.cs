using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos
{
	public interface IBookingRepository
	{
		Task<IEnumerable<Booking>> GetAllBookingsAsync();

		Task<Booking> GetBookingByIdAsync(int bookingId);

		Task AddBookingAsync(Booking booking);
		Task UpdateBookingAsync(Booking booking);
		Task DeleteBookingAsync(int bookingId);

		Task<bool> IsTableAvailableAsync(int tableId, DateTime date);

	}
}
