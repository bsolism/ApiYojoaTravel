using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class BookingDomainService : IBookingDomainservice
    {
         private readonly ApiDataContext dc;
        public BookingDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostBooking(Booking Booking)
        {
            bool requiredField;
            requiredField = (Booking.Client == null) ? true : false;
            requiredField = (Booking.ClientId == 0) ? true : false;
            requiredField = (Booking.PackageId == 0) ? true : false;
            requiredField = (Booking.PeopleQuantity == 0) ? true : false;
            requiredField = (Booking.TaxPercentage == 0) ? true : false;
            requiredField = (Booking.TotalAmount == 0) ? true : false;
            requiredField = (Booking.TotalTax == 0) ? true : false;
            return requiredField;
        }
        public async Task<ActionResult<Booking>> FindBooking(int BookingId)
        {
            var Booking = await dc.Booking.FirstOrDefaultAsync(x => x.BookingId == BookingId);
            return Booking;
        }
        public Booking DomainDeleteBooking(int id)
        {
            var Booking = dc.Booking.Find(id);
            if (Booking == null)
            {
                return null;
            }
            return Booking;
        }
    }
}