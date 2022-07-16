using CourseDiary.Wcf.Domain.Interfaces;
using CourseDiary.Wcf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Infrastructure
{
    public class TrainerRepository : ITrainerRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["CourseDiaryDBConnectionString"].ConnectionString;

        public async Task<bool> AddTrainer(Trainer trainer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string commandSql = "INSERT INTO [Trainers] ([Name], [Surname], [Email], [Password], [DateOfBirth]) " +
                        "VALUES (@Name, @Surname, @Email, @Password, @DateOfBirth)";
                    SqlCommand command = new SqlCommand(commandSql, connection);
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 255).Value = trainer.Name;
                    command.Parameters.Add("@Surname", SqlDbType.VarChar, 255).Value = trainer.Surname;
                    command.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = trainer.Email;
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 255).Value = trainer.Password;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.VarChar, 255).Value = trainer.DateOfBirth;

                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public async Task<List<Trainer>> GetAllTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string commandText = $"SELECT * FROM [Trainers]";
                    SqlCommand command = new SqlCommand(commandText, connection);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();

                    while (await dataReader.ReadAsync())
                    {
                        Trainer trainer;

                        try
                        {
                            trainer = new Trainer
                            {
                                Id = int.Parse(dataReader["Id"].ToString()),
                                Name = dataReader["Name"].ToString(),
                                Surname = dataReader["Surname"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                Password = dataReader["Password"].ToString(),
                                DateOfBirth = DateTime.Parse(dataReader["DateOfBirth"].ToString())
                            };
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        trainers.Add(trainer);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                trainers = new List<Trainer>();
            }

            return trainers;
        }
    }
}
