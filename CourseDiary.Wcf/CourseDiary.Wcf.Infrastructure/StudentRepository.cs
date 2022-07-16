using CourseDiary.Wcf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Infrastructure
{
    public class StudentRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["CourseDiaryDBConnectionString"].ConnectionString;

        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string commandSql = "INSERT INTO [Students] ([Name], [Surname], [Email], [Password], [BirthDate]) " +
                        "VALUES (@Name, @Surname, @Email, @Password, @BirthDate)";
                    SqlCommand command = new SqlCommand(commandSql, connection);
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 255).Value = student.Name;
                    command.Parameters.Add("@Surname", SqlDbType.VarChar, 255).Value = student.Surname;
                    command.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = student.Email;
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 255).Value = student.Password;
                    command.Parameters.Add("@BirthDate", SqlDbType.VarChar, 255).Value = student.BirthDate;

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

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string commandText = $"SELECT * FROM [Students]";
                    SqlCommand command = new SqlCommand(commandText, connection);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();

                    while (await dataReader.ReadAsync())
                    {
                        Student student;

                        try
                        {
                            student = new Student
                            {
                                Id = int.Parse(dataReader["Id"].ToString()),
                                Name = dataReader["Name"].ToString(),
                                Surname = dataReader["Surname"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                Password = dataReader["Password"].ToString(),
                                BirthDate = DateTime.Parse(dataReader["DateOfBirth"].ToString())
                            };
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        students.Add(student);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                students = new List<Student>();
            }

            return students;
        }
    }
}
