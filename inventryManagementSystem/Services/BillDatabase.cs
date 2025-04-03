using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventryManagementSystem.Models;
using MySql.Data.MySqlClient;

namespace inventryManagementSystem.Services
{
    class BillDatabase
    {   

        public BillDatabase() {

            DeleteOldBills();
        }
        private void ExecuteQuery(string query)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Query executed successfully! Rows affected: " + rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error executing query: " + ex.Message);
                }
            }
        }

        public void DeleteOldBills()
        {
            string query = "DELETE FROM bill WHERE created_at < CURDATE();";  // Delete records not created today
            ExecuteQuery(query);  // Execute the delete query
        }


        public void RemoveBillById(int id)
        {
            string query = $"DELETE FROM bill WHERE id = {id}";
            Console.WriteLine("id that came = " + id);
            ExecuteQuery(query);
        }

        public void AddBill(int id, string name, float dose, int days, float amount, float price,DateTime date)
        {
            string query = $"INSERT INTO bill (id, name, dose, days, amount, price, created_at) " +
               $"VALUES ({id}, '{name}', {dose}, {days}, {amount}, {price}, '{date.ToString("yyyy-MM-dd HH:mm:ss")}')";
            ExecuteQuery(query);
        }

        public List<BillModel> GetAllBills()
        {
            List<BillModel> bills = new List<BillModel>();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM bill";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BillModel bill = new BillModel(
                            Convert.ToInt32(reader["id"]),            
                            reader["name"].ToString(),              
                            Convert.ToSingle(reader["dose"]),        
                            Convert.ToInt32(reader["days"]),         
                            Convert.ToSingle(reader["amount"]),     
                            Convert.ToSingle(reader["price"]),      
                            Convert.ToDateTime(reader["created_at"]) 
                        );


                        bills.Add(bill);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error executing query: " + ex.Message);
                }
            }

            return bills;
        }


    }
}
