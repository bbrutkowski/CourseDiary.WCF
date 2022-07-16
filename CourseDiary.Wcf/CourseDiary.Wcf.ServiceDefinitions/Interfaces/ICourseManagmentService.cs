using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.ServiceDefinitions.Interfaces
{
    [ServiceContract]
    public interface ICourseManagmentService
    {
        [OperationContract]
        Task<bool> AddCourseAsync(Course course);

    }
}
