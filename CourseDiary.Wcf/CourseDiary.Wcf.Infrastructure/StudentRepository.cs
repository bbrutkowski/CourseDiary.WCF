using System.Configuration;

namespace CourseDiary.Wcf.Infrastructure
{
    public class StudentRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["CourseDiaryDBConnectionString"].ConnectionString;
    }
}
