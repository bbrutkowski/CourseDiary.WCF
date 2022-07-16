using CourseDiary.Wcf.Domain.Interfaces;
using CourseDiary.Wcf.Domain.Models;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Domain
{
    public interface ICourseService
    {
        Task<bool> AddCourseAsync(Course course);
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> AddCourseAsync(Course course)
        {
            return await _courseRepository.AddCourseAsync(course);
        }
    }
}
