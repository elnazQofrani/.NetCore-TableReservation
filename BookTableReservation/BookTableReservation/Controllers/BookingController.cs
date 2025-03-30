using AutoMapper;
using Azure.Core;
using Domain.Entities;
using Domain.Enums;
using BookTableReservation.Models;
using BusinessLayer.Repositories;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookTableReservation.CustomActionValidation;

namespace BookTableReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper mapper;
        private readonly ICustomerService _customerService;
        private readonly ISeatService _seatService;
        public BookingController(IBookingService _bookingService, IMapper mapper, ICustomerService _customerService, ISeatService _seatService)
        {

            this._bookingService = _bookingService;
            this.mapper = mapper;
            this._customerService = _customerService;
            this._seatService = _seatService;
        }

        
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] BookingDto bookingDto)
        {

            if (ModelState.IsValid)
            {
                var customer = await _customerService.GetCustomerByIdAsync(bookingDto.CustomerId);
                if (customer == null)
                    return NotFound("Customer not found.");
                var isSeatAvailable = await _seatService.IsSeatsAvailable(bookingDto.SeatId, bookingDto.BookingDateTime, bookingDto.StartTime);
                if (!isSeatAvailable)
                    return BadRequest("Seat is pre booked");
                var booking = mapper.Map<Booking>(bookingDto);
                booking.Status = BookingStatus.Confirmed;
                var result = await _bookingService.CreatAsync(booking);
                return Ok(new { Message = "Seat booked successfully", BookingId = result.Id });
            }
            else
            {

                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookingById([FromRoute] int id)
        {
            var booking = await _bookingService.GetById(id);
            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            var bookingDto = mapper.Map<BookingDto>(booking);
            return Ok(bookingDto);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                return BadRequest("Invalid request.");
            }

            var booking = await _bookingService.GetById(id);
            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            await _bookingService.Update(booking);

            return Ok(new { Message = "Booking updated successfully", BookingId = booking.Id });
        }


        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> CancelBooking([FromRoute] int id)
        {

            var booking = await _bookingService.GetById(id);
            if (booking == null)
                return NotFound("Booking not found");

            if (booking.Status == BookingStatus.Canceled)
                return BadRequest("This booking is already canceled.");

            booking.Status = BookingStatus.Canceled;

            await _bookingService.Update(booking);

            return Ok(new { Message = "Booking canceled successfully", BookingId = booking.Id });
        }
    }

}

