using CourseDiary.Wcf.Domain.Interfaces;
using CourseDiary.Wcf.Domain.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CourseDiary.Wcf.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["CourseDiaryDBConnectionString"].ConnectionString;

        public User GetUser(string userLogin)
        {
            User user = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string commandText = $"SELECT * FROM [Users] WHERE [Login] = @Login";

                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@UserLogin", SqlDbType.NVarChar, 255).Value = userLogin;

                    SqlDataReader dataReader = command.ExecuteReader();

                    dataReader.Read();

                    user = new User
                    {
                        Login = dataReader["Login"].ToString(),
                        Password = dataReader["Password"].ToString(),
                        Role = dataReader["Role"].ToString(),
                    };

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                user = null;
            }

            return user;
        }
    }
}
