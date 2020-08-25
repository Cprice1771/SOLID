using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SolidExamples.Services {
    public class SmtpEmailService : IEMail {
        private const string FROM_EMAIL = "noreply@leaflogix.com";

        public void SendEmail(string toEmail, string body) {
          
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress(FROM_EMAIL);
            MailAddress to = new MailAddress(toEmail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "LL Order";
            message.Body = body;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            client.SendAsync(message, Guid.NewGuid());
            message.Dispose();
            
        }



        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e) {
            String token = (string)e.UserState;
            if (e.Cancelled) {
                Console.WriteLine("[{0}] Send canceled.", token);
            }

            if (e.Error != null) {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            } else {
                Console.WriteLine("Message sent.");
            }
        }
    }
}
