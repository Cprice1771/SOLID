using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Services {
    public interface IEMail {
        void SendEmail(string toEmail, string body);

        
    }

    public interface ISMS {
        void SendSMS(int phoneNumber, string body);
    }
}
