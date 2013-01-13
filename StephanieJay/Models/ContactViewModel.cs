using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Configuration;

namespace StephanieJay.Models
{
    public class ContactViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string From { get; set; }

        [Required]
        public string ContactVia { get; set; }

        [Required]
        public string Message { get; set; }
    }
    
    public class Contact
    {
        public string From { get; set; }
        public string ContactVia { get; set; }
        public string Message { get; set; }
    }

    public class Email
    {
        public void Send(Contact contact)
        {
            MailMessage mail = new MailMessage(
                ConfigurationManager.AppSettings["MailFrom"],
                ConfigurationManager.AppSettings["MailTo"],
                "Enquiry via website djstephaniejay.com",
                contact.From + "\r\n\r\n" + contact.ContactVia + "\r\n\r\n" + contact.Message);

            new SmtpClient().Send(mail);
        }
    }
}