namespace Hotel_Vilobiot.Models;

public class Reservation
{
    public Reservation(DateTime checkIn, DateTime checkOut, int totalPrice, bool status)
    {
        CheckIn = checkIn;
        CheckOut = checkOut;
        TotalPrice = totalPrice;
        Status = status;
    }

    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int TotalPrice { get; set; }
    public bool Status { get; set; }
}
