using Microsoft.AspNetCore.Mvc;
using SolidExamples.Models;
using SolidExamples.Repository;
using SolidExamples.Services;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace SolidExamples.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {

        private IEMail emailService;
        private ISMS smsService;

        public OrderController(IEMail email, ISMS sms) {
            emailService = email;
            smsService = sms;
        }


        [HttpPost("/create")]
        public void CreateOrder(Order order) {

            var orderId = Guid.NewGuid();

         
            if (!string.IsNullOrEmpty(order.EmailAddress)) {
                emailService.SendEmail(order.EmailAddress, "Your order has been received!");
            }

            if(order.PhoneNumber.HasValue) {
                smsService.SendSMS(order.PhoneNumber.Value, "Your order has been received!");
            }

            new OrderRepository().CreateOrder(orderId, order.EmailAddress);
            
        }
    }
}