using Labb_1_ASP.NET_API___Databas.Data.Repos.IRepos;
using Labb_1_ASP.NET_API___Databas.Data.Repos;
using Labb_1_ASP.NET_API___Databas.Models;
using Labb_1_ASP.NET_API___Databas.Models.DTOs;
using Labb_1_ASP.NET_API___Databas.Services.IServices;

namespace Labb_1_ASP.NET_API___Databas.Services
{
	public class BookingService : IBookingService
	{
		private readonly IBookingRepository _bookingRepository;
		public BookingService(IBookingRepository bookingRepository)
		{
			_bookingRepository = bookingRepository;
		}
		public async Task AddBookingAsync(BookingDTO booking)
		{
			var newBooking = new Booking
			{
				FK_CustomerId = booking.FK_CustomerId,
				FK_TableId = booking.FK_TableId,
				BookingDate = booking.BookingDate,
				CustomerAmount = booking.CustomerAmount
			};
			await _bookingRepository.AddBookingAsync(newBooking);
		}

		public async Task DeleteBookingAsync(int bookingId)
		{
			await _bookingRepository.DeleteBookingAsync(bookingId);
		}

		public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
		{
			var listOfBookings = await _bookingRepository.GetAllBookingsAsync();
			return listOfBookings.Select(x => new BookingDTO
			{
				BookingId = x.Id,
				FK_CustomerId= x.FK_CustomerId,
				FK_TableId= x.FK_TableId,
				BookingDate = x.BookingDate,
				CustomerAmount = x.CustomerAmount
			}).ToList();
		}

		public async Task<BookingDTO> GetBookingByIdAsync(int bookingId)
		{
			var bookingGot = await _bookingRepository.GetBookingByIdAsync(bookingId);
			if (bookingGot == null)
			{
				return null;
			}
			return new BookingDTO
			{
				BookingId = bookingGot.Id,
				FK_CustomerId = bookingGot.FK_CustomerId,
				FK_TableId = bookingGot.FK_TableId,
				BookingDate = bookingGot.BookingDate,
				CustomerAmount = bookingGot.CustomerAmount
			};
		}

		public async Task UpdateBookingAsync(BookingDTO booking, int bookingId)
		{
			var updateTable = await _bookingRepository.GetBookingByIdAsync(bookingId);
			updateTable.FK_TableId = booking.FK_TableId;
			updateTable.FK_CustomerId = booking.FK_CustomerId;
			updateTable.BookingDate = booking.BookingDate;
			updateTable.CustomerAmount = booking.CustomerAmount;
			await _bookingRepository.UpdateBookingAsync(updateTable);
		}

		public async Task<bool> CheckTableAvailability(int tableId, DateTime date)
		{
			return await _bookingRepository.IsTableAvailableAsync(tableId, date);
		}

	}
}
