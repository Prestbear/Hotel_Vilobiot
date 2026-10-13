namespace Hotel_Vilobiot.DTO.Request;

public class RegisterRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
}