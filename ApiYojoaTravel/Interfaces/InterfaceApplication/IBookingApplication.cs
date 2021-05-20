using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IBookingApplication
    {
       Task<IEnumerable<Booking>> GetBooking();
        Task<ActionResult<Booking>> FindBooking(int bookingId);
        Task<IActionResult> AddBooking(Booking booking);
        Task<ActionResult> UpdateBooking(int id, Booking booking);
        Task<IActionResult> DeleteBooking(int bookingId);
    }
}