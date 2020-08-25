using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Services {
    public class TwilioService : IEMail, ISMS {
        public void SendEmail(string toEmail, string body) {
            //
        }

        public void SendSMS(int phoneNumber, string body) {
          //
        }
    }
}
