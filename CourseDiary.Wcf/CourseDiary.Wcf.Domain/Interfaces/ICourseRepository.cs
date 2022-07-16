using CourseDiary.Wcf.Domain.Models;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<bool> AddCourseAsync(Course course);
    }
}
