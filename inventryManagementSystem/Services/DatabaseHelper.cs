using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace inventryManagementSystem.Services
{
    public class DatabaseHelper
    {
        private static string connectionString = "server=localhost; database=inventrymangementsystem; user=root; password=;";

        // This method ensures that the connection is properly opened and closed
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
    }

}
