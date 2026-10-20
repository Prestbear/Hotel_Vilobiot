using AutoMapper;
using Hotel_Vilobiot.Data;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Models;

namespace Hotel_Vilobiot.Services.IGuestService;

public interface IGuestService
{
    public bool Register(RegisterRequest req);
    public Guest Login(string email, string password);
    public bool Verify(string email, string code);
    public bool DeleteGuest(int id);
    public bool UpdateGuest(int id, EditGuestRequest req);
}