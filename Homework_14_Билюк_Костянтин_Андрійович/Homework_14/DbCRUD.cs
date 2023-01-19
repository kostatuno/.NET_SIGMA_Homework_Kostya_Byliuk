using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Homework_14
{
    public class DbCRUD
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True";

        public void CreateTable()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                new SqlCommand("CREATE TABLE Users" +
                    "(" +
                    "   UserId INTEGER PRIMARY KEY," +
                    "   UserName VARCHAR(30)," +
                    "   PhoneNumber VARCHAR(30)" +
                    ");", connection).ExecuteNonQuery();
            }
        }

        public void Create(User user)
        {
            if (user.UserName.Length > 30 && user.PhoneNumber.Length > 30)
                throw new Exception("User's lengths is bigger than permissible");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand($"INSERT INTO Users(UserId, UserName, PhoneNumber) VALUES" +
                    $"('{user.UserId}','{user.UserName}', '{user.PhoneNumber}');", connection);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(string sqlSetExpression, User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                new SqlCommand($"UPDATE Users SET {sqlSetExpression} WHERE UserId = {user.UserId} AND " +
                    $"UserName = '{user.UserName}' AND PhoneNumber = '{user.PhoneNumber}'", connection).ExecuteNonQuery();
            }
        }

        public void Delete(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                new SqlCommand($"DELETE FROM Users WHERE UserId = {user.UserId} AND " +
                    $"UserName = '{user.UserName}' AND PhoneNumber = '{user.PhoneNumber}'", connection).ExecuteNonQuery();
            }
        }

        public List<User> Read()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var list = new List<User>();
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM Users", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2)));
                    }
                }
                return list;
            }

        }

    }
}