using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.ServiceDefinitions.Interfaces
{
    [ServiceContract]
    public interface IStudentManagmentService
    {
        [OperationContract]
        Task<bool> AddStudentAsync(Student student);
        Task<List<Student>> GetAllStudentsAsync();


    }
}
