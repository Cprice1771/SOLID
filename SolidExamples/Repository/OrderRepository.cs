using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SolidExamples.Repository {
    public class OrderRepository {


        private string connstring = "testconnection";

        private static void CreateCommand(string queryString,
          string connectionString) {
            using (SqlConnection connection = new SqlConnection(
                       connectionString)) {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateOrder(Guid orderId, string emailAddress) {
            CreateCommand($"Insert into Orders (OrderId, emailAddress) values ({orderId}, {emailAddress})", connstring);
        }
    }
}
