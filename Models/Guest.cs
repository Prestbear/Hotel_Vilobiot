namespace Hotel_Vilobiot.Models;

public class Guest
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public bool IsVerified { get; set; } = false;
    public string? Code { get; set; }
    //asdasd
}
