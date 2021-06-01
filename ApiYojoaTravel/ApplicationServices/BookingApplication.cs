using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.ApplicationServices
{
    public class BookingApplication : IBookingApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public BookingApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<Booking>> GetBooking()
        {
            return await dc.Booking.ToListAsync();
        }
        public Task<ActionResult<Booking>> FindBooking(int BookingId)
        {
            var Booking = uow.BookingDomainService.FindBooking(BookingId);
            if (Booking != null)
            {
                return Booking;
            }
            return null;

        }
        public async Task<IActionResult> AddBooking(Booking Booking)
        {
            var RequiredField = uow.BookingDomainService.PostBooking(Booking);
            if (!RequiredField)
            {
                dc.Booking.Add(Booking);
                await dc.SaveChangesAsync();
                return new ObjectResult(Booking);
            }
            return null;
        }
        public async Task<ActionResult> UpdateBooking(int id, Booking Booking)
        {
            if (id != Booking.BookingId)
            {
                return null;

            }
            dc.Entry(Booking).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeleteBooking(int BookingId)
        {
            var Booking = uow.BookingDomainService.DomainDeleteBooking(BookingId);
            if (Booking == null)
            {
                return null;
            }
            dc.Booking.Remove(Booking);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}