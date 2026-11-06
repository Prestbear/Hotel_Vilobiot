using AutoMapper;
using Hotel_Vilobiot.Data;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Enum;
using Hotel_Vilobiot.Models;
using Hotel_Vilobiot.Services.SMTP;

namespace Hotel_Vilobiot.Services.HotelServices;

public class HotelService : IHotelService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly SMTPService _smtpService;

    public HotelService(IMapper mapper, DataContext context, SMTPService smtpService)
    {
        _mapper = mapper;
        _context = context;
        _smtpService = smtpService;
    }

    public IEnumerable<Hotel> GetAllHotels()
    {
        var hotels = _context.Hotels.ToList();

        return hotels;
    }

    public IEnumerable<Room> GetHotelRooms(int hotelId)
    {
        var rooms = _context.Rooms.Where(x => x.HotelId == hotelId).ToList();

        if (rooms == null) return null;

        return rooms;
    }

    public Room GetRoomById(int roomId)
    {
        Room room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);

        if (room == null) return null;

        return room;
    }

    public IEnumerable<Room> GetAvailableRooms(int hotelId, DateTime checkIn, DateTime checkOut)
    {
        var today = DateTime.Today;

        if (checkIn.Date < today || checkOut <= checkIn)
        {
            return Enumerable.Empty<Room>();
        }



        return _context.Rooms
            .Where(room => room.HotelId == hotelId && !_context.Reservations.Any(res =>
                res.RoomId == room.Id &&
                res.Status == ReservationStatusEnum.active &&
                res.CheckIn < checkOut &&
                (res.CheckOut == null || res.CheckOut > checkIn)))
            .ToList();
    }

    public IEnumerable<Reservation> GetRoomBookedDates(int roomId)
    {
        var today = DateTime.Today;

        return _context.Reservations
            .Where(res => res.RoomId == roomId && (res.CheckOut == null || res.CheckOut >= today))
            .OrderBy(res => res.CheckIn)
            .ToList();
    }

    public bool CancelReservation(int reservationId, int guestId)
    {
        Reservation reservation = _context.Reservations.FirstOrDefault(x => x.Id == reservationId);
        if (reservation == null) return false;

        if (reservation.GuestId != guestId) return false;

        var guest = _context.Guests.FirstOrDefault(g => g.Id == guestId);
        if (guest == null) return false;

        var room = _context.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
        if (room == null)
        {
            return false;
        }

        if (DateTime.Now >= reservation.CheckIn)
        {
            return false;
        }

        double totalNights = (reservation.CheckOut.Value.Date - reservation.CheckIn.Date).TotalDays;

        reservation.TotalPrice = totalNights * room.PricePerNight;
        reservation.Status = ReservationStatusEnum.cancelled;

        _context.SaveChanges();

        _smtpService.SendReservationDetails(guest.Email, guest.FullName, reservation.Id);

        return true;
    }

    public bool CheckOut(CheckOutReqeust req)
    {
        var reservation = _context.Reservations.FirstOrDefault(x => x.Id == req.ReservationId);

        if (reservation == null || reservation.Status != ReservationStatusEnum.active)
        {
            return false;
        }

        if (DateTime.Now < reservation.CheckIn)
        {
            return false;
        }

        reservation.Status = ReservationStatusEnum.completed;

        reservation.CheckOut = DateTime.Now;

        _context.SaveChanges();
        return true;
    }

    public bool ReserveRoom(ReserveReqeuest req)
    {
        var guest = _context.Guests.FirstOrDefault(x => x.Id == req.GuestId);

        var roomExists = _context.Rooms.Any(r => r.Id == req.RoomId && r.HotelId == req.HotelId);
        if (!roomExists)
        {
            return false;
        }

        bool isConflict = _context.Reservations.Any(res =>
            res.RoomId == req.RoomId && res.Status == ReservationStatusEnum.active &&
            (!req.CheckOut.HasValue || res.CheckIn < req.CheckOut.Value) &&
            (res.CheckOut == null || res.CheckOut > req.CheckIn)
        );

        if (isConflict)
        {
            return false;
        }

        var room = _context.Rooms.FirstOrDefault(x => x.Id == req.RoomId);
        if (room == null || room.HotelId != req.HotelId) return false;

        var hotel = _context.Hotels.FirstOrDefault(x => x.Id == req.HotelId);
        if (hotel == null) return false;

        var newReservation = _mapper.Map<Reservation>(req);

        newReservation.Status = ReservationStatusEnum.active;

        newReservation.TotalPrice = 0;

        _context.Reservations.Add(newReservation);
        _context.SaveChanges();

        _smtpService.SendReservationDetails(guest.Email, guest.FullName, newReservation.Id);

        return true;
    }
}
