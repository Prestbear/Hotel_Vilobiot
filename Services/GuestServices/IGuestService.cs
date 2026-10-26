using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Models;

namespace Hotel_Vilobiot.Services.IGuestService;

public interface IGuestService
{
    public bool Register(RegisterRequest req);
    public Guest Login(LoginRequest req);
    public bool Verify(string email, string code);
    public bool UpdateGuest(int id, EditGuestRequest req);
    public bool DeleteGuest(int id);
}