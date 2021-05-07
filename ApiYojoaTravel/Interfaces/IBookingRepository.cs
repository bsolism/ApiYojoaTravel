using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBooking();
        void AddBooking(Booking booking);
        void DeleteBooking(int bookingId);
        Task UpdateBooking(Booking booking);
        Task<Booking> FindBooking(int bookingId);
    }
}