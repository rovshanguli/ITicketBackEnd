using DomainLayer.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using MimeKit;
using MimeKit.Text;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.DTOs.Order;
using ServiceLayer.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _accessor;
        private readonly LinkGenerator _generator;

        public EmailService(UserManager<AppUser> userManager, IWebHostEnvironment env, LinkGenerator generator, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _generator = generator;
            _accessor = accessor;
            _env = env;

        }


        public void Register(RegisterDto registerDto, string link)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ITicket", "code.test.iticket@gmail.com"));
            message.To.Add(new MailboxAddress(registerDto.FullName, registerDto.Email));
            message.Subject = "Confirm Email";
            string emailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Confirm.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }

            emailbody = emailbody.Replace("{{code}}", $"{link}").Replace("{{fullname}}",$"{registerDto.FullName}");
            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("code.test.iticket@gmail.com", "psutapkrmjbciuct");
            smtp.Send(message);
            smtp.Disconnect(true);
        }




        public async Task ConfirmEmail(string userId, string token)
        {

            AppUser user = await _userManager.FindByIdAsync(userId);

            await _userManager.ConfirmEmailAsync(user, token);
        }

        public void OrderCreate(string email)
        {

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("ITicket", "code.test.iticket@gmail.com"));

            message.To.Add(new MailboxAddress("", email));

            message.Subject = "Bizi Seçdiyiniz Üçün Təşəkkürlər";
            string emailbody = string.Empty;
            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Order.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }


            emailbody = emailbody.Replace("{{email}}", $"{email}");
            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("code.test.iticket@gmail.com", "psutapkrmjbciuct");
            smtp.Send(message);
            smtp.Disconnect(true);

        }

        public async void ForgotPassword(AppUser user,string url,ForgotPasswordDto forgotPassword)
        {
           
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("EduHome", "code.test.iticket@gmail.com"));

            message.To.Add(new MailboxAddress(user.FullName,forgotPassword.Email));
            message.Subject = "Reset Password";

            string emailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Reset.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }

           

            emailbody = emailbody.Replace("{{fullname}}", $"{user.FullName}").Replace("{{code}}", $"{url}");

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("code.test.iticket@gmail.com", "psutapkrmjbciuct");
            smtp.Send(message);
            smtp.Disconnect(true);
          
        }
    }
}