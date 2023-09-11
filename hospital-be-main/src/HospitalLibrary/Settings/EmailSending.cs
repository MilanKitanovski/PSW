using MimeKit;
using System;
using System.IO;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings
{
    public class EmailSending
    {
        public static MimeMessage CreateTxtEmail(string recipientName, string recipientEmail, string subject, string emailText)
        {
            var message = new MimeMessage();


            message.From.Add(new MailboxAddress(Settings.EmailingResources.SenderName, Settings.EmailingResources.SenderEmail));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));

            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = @"" + emailText
            };
            return message;
        }

        public static MimeMessage CreateAttachedEmail(string recipientName, string recipientEmail, string subject, string emailText, string attachementName, byte[] attachment)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Settings.EmailingResources.SenderName, Settings.EmailingResources.SenderEmail));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));

            message.Subject = subject;
            if (attachment != null)
            {
                var bodyBuilder = new BodyBuilder();
                if (attachment != null)
                    bodyBuilder.Attachments.Add(attachementName, attachment);
                bodyBuilder.HtmlBody = emailText;
                message.Body = bodyBuilder.ToMessageBody();
            }
            return message;
        }
        public static async Task SendEmailAsync(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(Settings.EmailingResources.SmtpAddress, 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(Settings.EmailingResources.SenderEmail, Settings.EmailingResources.SenderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

        public static byte[] CreateEmailAttachment(String path)
        {
            FileStream stream = File.OpenRead(path);
            byte[] fileBytes = new byte[stream.Length];

            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();
            return fileBytes;
        }
    }
}
