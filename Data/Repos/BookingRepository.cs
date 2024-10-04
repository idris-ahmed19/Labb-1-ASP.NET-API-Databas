using Microsoft.EntityFrameworkCore;
using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Models;

namespace Labb_1_ASP.NET_API___Databas.Data.Repos
{
	public class BookingRepository : IBookingRepository
	{
		private readonly RestaurantContext _context;
		public BookingRepository(RestaurantContext context)

		{
			_context = context;
		}

		public async Task AddBookingAsync(Booking booking)
		{
			_context.Bookings.Add(booking);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteBookingAsync(int bookingId)
		{
			var removeBooking = await _context.Bookings.FindAsync(bookingId);
			if (removeBooking != null)
			{
				_context.Bookings.Remove(removeBooking);

			}
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
		{
			var bookingList = await _context.Bookings.ToListAsync();
			return bookingList;
		}

		public async Task<Booking> GetBookingByIdAsync(int bookingId)
		{
			var bookingGot = await _context.Bookings.FindAsync(bookingId);
			return bookingGot;
		}

		public async Task UpdateBookingAsync(Booking booking)
		{
			_context.Bookings.Update(booking);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> IsTableAvailableAsync(int tableId, DateTime date)
		{
			var isBooked = await _context.Bookings
				.AnyAsync(b => b.FK_TableId == tableId && b.BookingDate == date);

			return !isBooked;
		}

	}
}
