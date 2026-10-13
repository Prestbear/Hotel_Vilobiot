// using AutoMapper;
// using Microsoft.AspNetCore.Identity.Data;
// using Microsoft.EntityFrameworkCore;
// using Hotel_Vilobiot.Data;
// using Hotel_Vilobiot.DTO.Request;
// using Hotel_Vilobiot.Models;
// using RegisterRequest = Hotel_Vilobiot.DTO.Request.RegisterRequest;
// //
// using Hotel_Vilobiot.Services.SMTP;
// using Hotel_Vilobiot.Services.UserService; // ?
//
// namespace Hotel_Vilobiot.Services.GuestService;
//
// public class GuestService : IGuestService
// {
//     private readonly IMapper _mapper;
//     private readonly DataContext _context;
//
//     public GuestService(IMapper mapper, DataContext context)
//     {
//         _mapper = mapper;
//         _context = context;
//     }
//
//     public bool Register(RegisterRequest req)
//     {
//         var guest = _context.Guests.FirstOrDefault(x => x.Email == req.Email);
//         if (guest != null) return false;
//         req.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);
//         var guestToCreate = _mapper.Map<Guest>(req);
//         _context.Guests.Add(guestToCreate);
//         _context.SaveChanges();
//         var mail = SMTPService.SendEmail(req.Email, req.FullName);
//         return true;
//     }
//
//     public Guest Login(string email, string password)
//     {
//         var guestexist = _context.Guests.FirstOrDefault
//             (x => x.Email == email && x.Password == password);
//         if (guestexist != null) return null;
//         if (!BCrypt.Net.BCrypt.Verify(password, guestexist.Password)) return null;
//         return guestexist;
//     }
//
//     public bool Verify(string email, string code)
//     {
//         throw new NotImplementedException();
//     }
//
//     public bool DeleteGuest(int id)
//     {
//         var guest = _context.Guests.FirstOrDefault(x => x.Id == id);
//         if (guest == null) return false;
//         _context.Guests.Remove(guest);
//         _context.SaveChanges();
//         return true;
//     }
//
//     public bool UpdateGuest(int id, EditGuestRequest req)
//     {
//         var guest = _context.Guests.FirstOrDefault(x => x.FullName == req.FullName);
//         if (guest == null) return false;
//         _mapper.Map(req, guest);
//         _context.Update(guest);
//         _context.SaveChanges();
//         return true;
//     }
// }