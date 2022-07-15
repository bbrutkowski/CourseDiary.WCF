using System.Configuration;

namespace CourseDiary.Wcf.Infrastructure
{
    public class CourseRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["CourseDiaryDBConnectionString"].ConnectionString;

    }
}
