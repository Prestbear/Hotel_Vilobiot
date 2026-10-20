using Hotel_Vilobiot.Enum;

public class Room
{
    public Room(int number, int floor)
    {
        Number = number;
        Floor = floor;
    }

    public int Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public double PricePerNight { get; set; }
    public RoomTypeEnum RoomType { get; set; }
    public bool Status { get; set; }
}