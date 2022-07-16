using CourseDiary.Wcf.ServiceDefinitions.Interfaces;
using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Client.Managments
{
    public class CourseManagmentClient : ClientBase<ICourseManagmentService>
    {
        public async Task<bool> AddCourseAsync(Course course)
        {
            return await Channel.AddCourseAsync(course);
        }

    }
}
