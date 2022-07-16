using CourseDiary.Wcf.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<bool> AddStudentAsync(Student student);
        Task<List<Student>> GetAllStudentsAsync();

    }
}
