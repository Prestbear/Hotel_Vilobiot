using Hotel_Vilobiot.Enum;

namespace Hotel_Vilobiot.Models;

public class Guest
{
    public Guest(string fullName, string email, string password, string phone)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        Phone = phone;
    }

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public bool IsVerified { get; set; } = false;
    public string? Code { get; set; }
}
