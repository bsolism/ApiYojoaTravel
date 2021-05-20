using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IBookingDomainservice
    {
        bool PostBooking(Booking Booking);
        Task<ActionResult<Booking>> FindBooking(int BookingId);
        Booking DomainDeleteBooking(int id);
    }
}