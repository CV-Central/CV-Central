using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using CV_Central.Models;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using CV_Central.Context;
using Microsoft.EntityFrameworkCore;


namespace CV_Central.App.Services
{
    public class EmailRepository
    {
        private readonly Email _emailSettings;

          public EmailRepository(IOptions<Email> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public void SendEmail(string Email, string subject, string body, User user)
        {
            Console.WriteLine(Email);
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            emailMessage.To.Add(new MailboxAddress("", Email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text =$"Hola, {user.Name},\nESta es tu contraseña {user.Password}." };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_emailSettings.SmtpServer, _emailSettings.Port, false);
                client.Authenticate(_emailSettings.Username, _emailSettings.Password);
                client.Send(emailMessage);
                client.Disconnect(true);
            
            }
        }

        /* Funcion para enviar correo de confirmación de registro */
        public void ConfirmRegistration(string Email, string subject, string body, User user)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            emailMessage.To.Add(new MailboxAddress("", Email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text =$"Bienvenid@ a CVCentral {user.Name}\n Tu registro se completo correctamente, ya eres uno de nuestro usuarios." };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_emailSettings.SmtpServer, _emailSettings.Port, false);
                client.Authenticate(_emailSettings.Username, _emailSettings.Password);
                client.Send(emailMessage);
                client.Disconnect(true);
            
            }
        }
    }
}