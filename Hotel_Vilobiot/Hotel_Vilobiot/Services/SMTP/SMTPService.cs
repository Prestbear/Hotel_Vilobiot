using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Hotel_Vilobiot.Services.SMTP;

public class SMTPService
{
    public const string SenderEmail = "giorgikoberidze67@gmail.com";
    public const string AppPassword = "rxfi azsl lsvo pacr";

    public static string GenerateCode()
        => RandomNumberGenerator.GetInt32(0, 999_999).ToString("D6");

    public static async Task<string> SendEmail(string email, string username)
    {
        string code = GenerateCode();

        string htmlContent = $"""
                              <div style="font-family:Arial">   
                                  <h2>Hello, {username}!</h2>
                                  <p>your code is:</p>
                                  <h1 style="letter-spacing:6px">{code}</h1>
                                  <p>The code works onley 5 minute.</p>
                              </div>
                              """;
        using var mail = new MailMessage();
        mail.From = new MailAddress(SenderEmail, AppPassword);
        mail.To.Add(email);
        mail.Body = htmlContent;
        mail.IsBodyHtml = true;
        using var SMTP = new SmtpClient("smtp.gmail.com", 587)
        {
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(SenderEmail, AppPassword),
        };
        await SMTP.SendMailAsync(mail);
        return htmlContent;
    }
}