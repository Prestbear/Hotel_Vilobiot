using AutoMapper;
using Hotel_Vilobiot.Data;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Models;
using Hotel_Vilobiot.Services.SMTP;

namespace Hotel_Vilobiot.Services.GuestService;

public class GuestService : IGuestService.IGuestService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public GuestService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public bool Register(RegisterRequest req)
    {
        var registerGuest = _context.Guests.FirstOrDefault(x => x.Email == req.Email);
        if (registerGuest != null) return false;

        req.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);
        var guestToCreate = _mapper.Map<Guest>(req);

        _context.Guests.Add(guestToCreate);
        _context.SaveChanges();
        var mail = SMTPService.SendEmail(req.Email, req.FullName);
        return true;
    }

    public Guest Login(LoginRequest req)
    {
        var loginGuest = _context.Guests.FirstOrDefault
            (x => x.Email == req.Email && x.Password == req.Password);
        if (loginGuest == null) return null;
        if (!BCrypt.Net.BCrypt.Verify(req.Password, loginGuest.Password)) return null;
        return loginGuest;
    }

    public bool Verify(string email, string code)
    {
        var verifyGuest = _context.Guests.FirstOrDefault(x => x.Email == email && x.Code == code);
        if (verifyGuest == null) return false;
        verifyGuest.Code = null;
        _context.SaveChanges();
        return true;
    }

    public bool UpdateGuest(int id, EditGuestRequest req)
    {
        var updateGuest = _context.Guests.FirstOrDefault(x => x.Id == id);
        if (updateGuest == null) return false;
        _mapper.Map(req, updateGuest);
        _context.Update(updateGuest);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteGuest(int id)
    {
        var deleteGuest = _context.Guests.FirstOrDefault(x => x.Id == id);
        if (deleteGuest == null) return false;
        _context.Guests.Remove(deleteGuest);
        _context.SaveChanges();
        return true;
    }
}