namespace Hotel_Vilobiot.Models;

public class Hotel
{
    public Hotel(string name, string city, decimal stars)
    {
        Name = name;
        City = city;
        Stars = stars;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string  City { get; set; }
    public decimal Stars { get; set; }
    public List<Room> Rooms { get; set; }
    //me var jumbera
    //babus kuntebi
}
