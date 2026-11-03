using FluentValidation;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Models;
using Hotel_Vilobiot.Services.HotelServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Vilobiot.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hs;

    public HotelController(IHotelService hotelService)
    {
        _hs = hotelService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Hotel>> GetAllHotels()
    {
        var hotels = _hs.GetAllHotels();
        return Ok(hotels);
    }

    [HttpGet("{hotelId}/rooms")]
    public ActionResult<IEnumerable<Room>> GetHotelRooms(int hotelId)
    {
        var rooms = _hs.GetHotelRooms(hotelId);
        if (rooms == null)
        {
            return NotFound($"Hotel with ID {hotelId} not found or has no rooms.");
        }
        return Ok(rooms);
    }

    [HttpGet("rooms/{roomId}")]
    public ActionResult<Room> GetRoomById(int roomId)
    {
        var room = _hs.GetRoomById(roomId);
        if (room == null)
        {
            return NotFound($"Room with ID {roomId} not found.");
        }
        return Ok(room);
    }

    [HttpGet("{hotelId}/available-rooms")]
    public ActionResult<IEnumerable<Room>> GetAvailableRooms(int hotelId, [FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
    {
        var today = DateTime.Today;

        if (checkIn.Date < today)
        {
            return BadRequest("Invalid date. Check-in date cannot be in the past!");
        }

        if (checkOut <= checkIn)
        {
            return BadRequest("Invalid date. Check-out date must be later than the check-in date!");
        }

        var availableRooms = _hs.GetAvailableRooms(hotelId, checkIn, checkOut);
        return Ok(availableRooms);
    }

    [HttpGet("rooms/{roomId}/booked-dates")]
    public ActionResult<IEnumerable<Reservation>> GetRoomBookedDates(int roomId)
    {
        var bookedDates = _hs.GetRoomBookedDates(roomId);
        return Ok(bookedDates);
    }

    [HttpPost("reserve")]
    public IActionResult ReserveRoom([FromBody] ReserveReqeuest req, IValidator<ReserveReqeuest> validator)
    {
        var result = validator.Validate(req);

        if (!result.IsValid) return BadRequest(result);

        var success = _hs.ReserveRoom(req);
        if (!success)
        {
            return BadRequest("The room is already booked for the selected dates.");
        }

        return Ok("Reservation created successfully!");
    }

    [HttpPatch("cancel-reservation")]
    public IActionResult CancelReservation(int reservationId, int guestId)
    {
        var cancelReservation = _hs.CancelReservation(reservationId, guestId);

        if (!cancelReservation) return BadRequest("Reservation doesn't exist or belongs to another Guest!");

        return Ok("Reservation cancelled");
    }
}