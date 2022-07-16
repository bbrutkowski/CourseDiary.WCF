using CourseDiary.Wcf.Domain.Interfaces;
using CourseDiary.Wcf.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Domain
{
    public interface IStudentService
    {
        Task<bool> AddStudentAsync(Student student);
        Task<List<Student>> GetAllStudentsAsync();
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            return await _studentRepository.AddStudentAsync(student);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

    }
}
