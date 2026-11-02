using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Models;

namespace Hotel_Vilobiot.Services.HotelServices;

public interface IHotelService
{
    IEnumerable<Hotel> GetAllHotels();
    IEnumerable<Room> GetHotelRooms(int hotelId);
    Room GetRoomById(int roomId);
    IEnumerable<Room> GetAvailableRooms(int hotelId, DateTime checkIn, DateTime checkOut);
    IEnumerable<Reservation> GetRoomBookedDates(int roomId);
    bool ReserveRoom(ReserveReqeuest req);
    bool CancelReservation(int reservationId);
    bool CheckOut(CheckOutReqeust req);
}