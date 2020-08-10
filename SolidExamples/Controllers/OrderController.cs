using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidExamples.Models;

namespace SolidExamples.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
		private const string MAJOR_VERSION_NUM = "3";
		private const string MINOR_VERSION_NUM = "2";
		private const string PATCH_VERSION_NUM = "1";

		private const string FROM_EMAIL = "noreply@leaflogix.com";
		private string connstring = "testconnection";

		[HttpGet("/version")]
		public string GetVersionNumber() {
			return MAJOR_VERSION_NUM + "." + MINOR_VERSION_NUM + "." + PATCH_VERSION_NUM;
		}

		[HttpGet("/major-version")]
		public string GetMajorVersionNumber() {
			return MAJOR_VERSION_NUM;
		}

		[HttpGet("/minor-version")]
		public string GetMinorVersionNumber() {
			return MINOR_VERSION_NUM;
		}

		[HttpGet("/patch-version")]
		public string GetPatchVersionNumber() {
			return PATCH_VERSION_NUM;
		}

		[HttpPost("/create")]
        public void CreateOrder(Order order) {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress(FROM_EMAIL);
            MailAddress to = new MailAddress(order.EmailAddress);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "LL Order";
            message.Body = "Your order has been received!";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            var orderId = Guid.NewGuid();
            client.SendAsync(message, orderId);
            message.Dispose();

            CreateCommand($"Insert into Orders (OrderId, emailAddress) values ({orderId}, {order.EmailAddress})", connstring);
        }

		private static void CreateCommand(string queryString,
			string connectionString) {
			using (SqlConnection connection = new SqlConnection(
					   connectionString)) {
				SqlCommand command = new SqlCommand(queryString, connection);
				command.Connection.Open();
				command.ExecuteNonQuery();
			}
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
