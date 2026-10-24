namespace Hotel_Vilobiot.Models;

public class Reservation
{


    public int Id { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public bool IsActive => DateTime.Now >= CheckIn && (CheckOut == null || DateTime.Now <= CheckOut.Value);
    public int TotalPrice { get; set; }
}
