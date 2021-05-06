using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApiDataContext dc;

        public BookingRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Booking>> GetBooking()
        {
            return await dc.Booking.ToListAsync();
        }
        public void AddBooking(Booking booking)
        {
            dc.Booking.AddAsync(booking);
        }
        public void DeleteBooking(int bookingId)
        {
            var booking = dc.Booking.Find(bookingId);
            dc.Booking.Remove(booking);
        }
        public async Task UpdateBooking(Booking booking)
        {
            dc.Entry(booking).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<Booking> FindBooking(int bookingId)
        {
            return await dc.Booking.FindAsync(bookingId);
        }
    }
}