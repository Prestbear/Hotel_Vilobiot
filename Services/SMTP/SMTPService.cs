using Microsoft.Identity.Client.NativeInterop;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using Hotel_Vilobiot.Data;
using Hotel_Vilobiot.Models;

namespace Hotel_Vilobiot.Services.SMTP;

public class SMTPService
{
    public const string SenderEmail = "giorgikoberidze67@gmail.com";
    public const string AppPassword = "rxfi azsl lsvo pacr";

    private readonly DataContext _context;

    public SMTPService(DataContext context)
    {
        _context = context;
    }

    private static readonly ConcurrentDictionary<string, (string Code, DateTime Expiry)> Codes = new();

    public static string GenerateCode()
        => RandomNumberGenerator.GetInt32(0, 999_999).ToString("D6");

    public static async Task<string> SendEmail(string email, string username)
    {
        string code = GenerateCode();

        string htmlContent = $"""
                              <div style="font-family:Arial">
                                  <h2>Hello, {username}!</h2>
                                  <p>Your verification code is:</p>
                                  <h1 style="letter-spacing:6px">{code}</h1>
                                  <p>The code expires in 5 minutes.</p>
                              </div>
                              """;

        using var mail = new MailMessage();
        mail.From = new MailAddress(SenderEmail);
        mail.To.Add(email);
        mail.Subject = "Email Verification Code";
        mail.Body = htmlContent;
        mail.IsBodyHtml = true;

        using var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(SenderEmail, AppPassword)
        };

        await smtp.SendMailAsync(mail);

        Codes[email] = (code, DateTime.UtcNow.AddMinutes(5)); // 5 min wait
        return code;
    }

    public static bool VerifyCode(string email, string code)
    {
        if (!Codes.TryGetValue(email, out var saved))
            return false;

        if (DateTime.UtcNow > saved.Expiry || saved.Code != code)
        {
            if (DateTime.UtcNow > saved.Expiry)
                Codes.TryRemove(email, out _);

            return false;
        }

        Codes.TryRemove(email, out _);
        return true;
    }

    public async Task<bool> SendReservationDetails(string email, string fullName, int reservationId)
    {
        var reservation = _context.Reservations.FirstOrDefault(x => x.Id == reservationId);
        var hotel = _context.Hotels.FirstOrDefault(x => x.Id == reservation.HotelId);
        var room = _context.Rooms.FirstOrDefault(x => x.Id == reservation.RoomId);

        string htmlContent = $"""
                              <div style="font-family:Arial">
                                  <h2>Hello, {fullName}!</h2>
                                  <p>Your Reservation details:</p>
                                  <ul>
                                      <li><strong>Hotel:</strong> {hotel.Name}</li>
                                      <li><strong>Floor:</strong> {room.Floor}</li>
                                      <li><strong>Room Number:</strong> {room.Number}</li>
                                      <li><strong>Room type:</strong> {room.RoomType.ToString()}</li>
                                      <li><strong>Room Price per Night:</strong> {room.PricePerNight}</li>
                                      <li><strong>Check-In:</strong> {reservation.CheckIn:yyyy-MM-dd}</li>
                                      <li><strong>Check-Out:</strong> {reservation.CheckOut?.ToString("yyyy-MM-dd") ?? "N/A"}</li>
                                  </ul>
                                  <p>Enjoy Your Stay at Hotel Vilobiot!</p>
                                  <hr style="border: none; border-top: 1px solid #eee; margin-top: 20px;" />
                                  <i style="font-size: 12px; color: #777;">
                                  <strong>Hotel Vilobiot LLC</strong><br />
                                  All rights reserved.
                                  </i>
                              </div>
                              """;

        using var mail = new MailMessage();
        mail.From = new MailAddress(SenderEmail);
        mail.To.Add(email);
        mail.Subject = "Hotel Vilobiot Reservation Details";
        mail.Body = htmlContent;
        mail.IsBodyHtml = true;

        using var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(SenderEmail, AppPassword)
        };

        await smtp.SendMailAsync(mail);

        return true;
    }
}
