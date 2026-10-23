using System.Collections.Concurrent;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Hotel_Vilobiot.Services.SMTP;

public class SMTPService
{
    public const string SenderEmail = "giorgikoberidze67@gmail.com";
    public const string AppPassword = "rxfi azsl lsvo pacr";

    private static readonly ConcurrentDictionary<string, (string Code, DateTime Expiry)> Codes = new();

    public static string GenerateCode()
        => RandomNumberGenerator.GetInt32(0, 999_999).ToString("D6");

    public static async Task<bool> SendEmail(string email, string username)
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

        Codes[email] = (code, DateTime.UtcNow.AddMinutes(5)); // 5 min whait
        return true;
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
}
// using System.Net;
// using System.Net.Mail;
// using System.Security.Cryptography;
//
// namespace Hotel_Vilobiot.Services.SMTP;
//
// public class SMTPService
// {
//     public const string SenderEmail = "giorgikoberidze67@gmail.com";
//     public const string AppPassword = "rxfi azsl lsvo pacr";
//
//     public static string GenerateCode()
//         => RandomNumberGenerator.GetInt32(0, 999_999).ToString("D6");
//
//     public static async Task<string> SendEmail(string email, string username)
//     {
//         string code = GenerateCode();
//
//         string htmlContent = $"""
//                               <div style="font-family:Arial">   
//                                   <h2>Hello, {username}!</h2>
//                                   <p>your code is:</p>
//                                   <h1 style="letter-spacing:6px">{code}</h1>
//                                   <p>The code works onley 5 minute.</p>
//                               </div>
//                               """;
//         using var mail = new MailMessage();
//         mail.From = new MailAddress(SenderEmail, AppPassword);
//         mail.To.Add(email);
//         mail.Body = htmlContent;
//         mail.IsBodyHtml = true;
//         using var SMTP = new SmtpClient("smtp.gmail.com", 587)
//         {
//             Port = 587,
//             EnableSsl = true,
//             Credentials = new NetworkCredential(SenderEmail, AppPassword),
//         };
//         await SMTP.SendMailAsync(mail);
//         return htmlContent;
//         // return code;
//     }
// }