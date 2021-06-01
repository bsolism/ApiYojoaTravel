using System.Collections.Generic;
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
        public Task<IEnumerable<Booking>> GetBooking()
        {
            return uow.BookingApplication.GetBooking();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<Booking>> GetById(int id)
        {
            var booking = uow.BookingApplication.FindBooking(id);
            return booking;
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            var activit = await uow.BookingApplication.AddBooking(booking);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, Booking booking)
        {
            var Booking = await uow.BookingApplication.UpdateBooking(id, booking);
            if (Booking == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var Booking = await uow.BookingApplication.DeleteBooking(id);
            if (Booking == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}