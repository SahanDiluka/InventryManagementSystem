using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventryManagementSystem.Models;
using MySql.Data.MySqlClient;

namespace inventryManagementSystem.Services
{
    public class MedicineDatabase
    {
        public static List<Medicine> GetAllMedicines()
        {
            List<Medicine> medicines = new List<Medicine>();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM medicine";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    
                   

                    while (reader.Read())
                    {
                        
                        Medicine medicine = new Medicine(
                            Convert.ToInt32(reader["id"]),              // id
                            reader["name"].ToString(),                 // name
                            Convert.ToSingle(reader["dose"]),          // dose (convert to float)
                            reader["companyName"].ToString(),          // companyName
                            Convert.ToDateTime(reader["exDate"]),      // exDate
                            Convert.ToDateTime(reader["manufacturedDate"]), // manufacturedDate
                            Convert.ToSingle(reader["amount"]),        // amount
                            Convert.ToSingle(reader["price"])          // price
                        );

                       
                        medicines.Add(medicine);
                    }

                 
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error executing query: " + ex.Message);
                }
            }

            return medicines;
        }



        public void ExecuteQuery(string query)
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



        public void DeleteMedicineById(int id)
        {
            string query = $"DELETE FROM medicine WHERE id = {id}";  // Query to delete by id
            ExecuteQuery(query);  // Executes the query
        }

        public void UpdateMedicineById(int id, Medicine updatedMedicine)
        {
            string query = $"UPDATE medicine SET " +
                           $"name = '{updatedMedicine.Name}', " +
                           $"dose = {updatedMedicine.Dose}, " +
                           $"companyName = '{updatedMedicine.CompanyName}', " +
                           $"exDate = '{updatedMedicine.ExDatee.ToString("yyyy-MM-dd")}', " +
                           $"manufacturedDate = '{updatedMedicine.ManufacturedDate.ToString("yyyy-MM-dd")}', " +
                           $"amount = {updatedMedicine.Amount}, " +
                           $"price = {updatedMedicine.Price} " +
                           $"WHERE id = {id}";

            ExecuteQuery(query);
        }

        public void UpdateMedicineByName(string name, Medicine updatedMedicine)
        {
            string query = $"UPDATE medicine SET " +
                           $"name = '{updatedMedicine.Name}', " +
                           $"dose = {updatedMedicine.Dose}, " +
                           $"companyName = '{updatedMedicine.CompanyName}', " +
                           $"exDate = '{updatedMedicine.ExDatee.ToString("yyyy-MM-dd")}', " +
                           $"manufacturedDate = '{updatedMedicine.ManufacturedDate.ToString("yyyy-MM-dd")}', " +
                           $"amount = {updatedMedicine.Amount}, " +
                           $"price = {updatedMedicine.Price} " +
                           $"WHERE name = '{name}'";

            ExecuteQuery(query);
        }
        public void Create(int id, string name, float dose, string companyName, DateTime exDate, DateTime manufacturedDate, float amount, float price)
        {
            string query = $"INSERT INTO medicine (id, name, dose, companyName, exDate, manufacturedDate, amount, price) " +
                           $"VALUES ({id}, '{name}', {dose}, '{companyName}', '{exDate.ToString("yyyy-MM-dd")}', '{manufacturedDate.ToString("yyyy-MM-dd")}', {amount}, {price})";
            ExecuteQuery(query);
        }
        public void UpdateMedicineAmount(int id, float newAmount)
        {
           
            string query = $"UPDATE medicine SET amount = {newAmount} WHERE id = {id}";
            ExecuteQuery(query);
        }
        public void UpdateMedicineAvailability(int id, bool availability)
        {
           
            string query = $"UPDATE medicine SET available = {availability} WHERE id = {id}";
            ExecuteQuery(query);
        }

    }
}
