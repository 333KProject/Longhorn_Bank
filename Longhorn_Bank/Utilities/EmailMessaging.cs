using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//TODO: You need to add these using statements to get mail to work
using System.Net.Mail;
using System.Net;

namespace Longhorn_Bank.Messaging
{
    public class EmailMessaging
    {
        public static void SendEmail(String toEmailAddress, String emailSubject, String emailBody)
        {

            //Create an email client to send the emails
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("longhornbank1@gmail.com", "dfjk2017"),
                EnableSsl = true
            };

            //Add anything that you need to the body of the message
            // /n is a new line – this will add some white space after the main body of the message
            String finalMessage = emailBody + "Sent by Team 9 --- Longhorn Bank ";

            //Create an email address object for the sender address
            MailAddress senderEmail = new MailAddress("longhornbank1@gmail.com", "Group9Group9");


            MailMessage mm = new MailMessage();
            mm.Subject = "Team 9 - " + emailSubject;
            mm.Sender = senderEmail;
            mm.From = senderEmail;
            mm.To.Add(new MailAddress(toEmailAddress));
            mm.Body = finalMessage;
            client.Send(mm);
        }

    }
}
