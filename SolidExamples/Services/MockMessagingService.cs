using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Services {
    public class MockMessagingService : ISMS, IEMail {
        public void SendEmail(string toEmail, string body) {
            Console.WriteLine(body);
        }

        public void SendSMS(int phoneNumber, string body) {
            Console.WriteLine(body);
        }
    }
}
