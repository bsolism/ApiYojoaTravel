using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IUnitOfWork uow;
        public BookingController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            var Booking = await uow.BookingRepository.GetBooking();
            return Ok(Booking);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingById(int bookingId)
        {
            return await uow.BookingRepository.FindBooking(bookingId);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            uow.BookingRepository.AddBooking(booking);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }
            await uow.BookingRepository.UpdateBooking(booking);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            uow.BookingRepository.DeleteBooking(bookingId);
            await uow.SaveAsync();
            return Ok(bookingId);
        }
    }
}