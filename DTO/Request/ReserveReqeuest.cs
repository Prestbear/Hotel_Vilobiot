namespace Hotel_Vilobiot.DTO.Request;

public class ReserveReqeuest
{
    public int GuestId { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
}