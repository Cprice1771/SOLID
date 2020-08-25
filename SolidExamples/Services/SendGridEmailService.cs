using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Services {
    public class SendGridEmailService : IEMail, ISMS {
        public void SendEmail(string toEmail, string body) {
            //Do sendgrid stuff
        }

        public void SendSMS(int phoneNumber, string body) {
            //do sendgrid sms
        }
    }
}
