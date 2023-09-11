using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Settings;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class EmailService : IEmailService
    {
        public Task SendEmail(MimeMessage emailMessage)
        {
            return EmailSending.SendEmailAsync(emailMessage);
        }
    }
}
