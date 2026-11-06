using Hotel_Vilobiot.Enum;

namespace Hotel_Vilobiot.Models;

public class Reservation
{


    public int Id { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public ReservationStatusEnum Status { get; set; }
    public bool IsActive => Status == ReservationStatusEnum.active;
    public double TotalPrice { get; set; }
}
