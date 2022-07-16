using CourseDiary.Wcf.ServiceDefinitions.Interfaces;
using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Client.Managments
{
    public class StudentManagmentClient : ClientBase<IStudentManagmentService>
    {
        public async Task<bool> AddStudentAsync(Student student)
        {
            return await Channel.AddStudentAsync(student);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await Channel.GetAllStudentsAsync();
        }
    }
}
