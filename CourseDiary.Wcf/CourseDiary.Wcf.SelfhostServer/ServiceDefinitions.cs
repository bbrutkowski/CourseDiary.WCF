using CourseDiary.Wcf.Domain;
using CourseDiary.Wcf.Domain.Interfaces;
using CourseDiary.Wcf.Infrastructure;
using CourseDiary.Wcf.ServiceDefinitions.Interfaces;
using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.SelfhostServer
{
    public class ServiceDefinitions : IUserManagmentService, ITrainerManagmentService, IStudentManagmentService, ICourseManagmentService
    {
        private readonly UserService _userService;
        private readonly ITrainerService _trainerService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly Mapper _mapper;

        public ServiceDefinitions(ITrainerService trainerService, IStudentService studentService, ICourseService courseService)
        {
            _userService = new UserService(new UserRepository());
            _trainerService = trainerService;
            _studentService = studentService;
            _mapper = new Mapper();
            _courseService = courseService;
        }
        public bool CheckUserCredentials(string userLogin, string userPassword)
        {
            return _userService.CheckUserCredentials(userLogin, userPassword);
        }

        public User GetUser(string userLogin)
        {
            return _mapper.MapUserToContract(_userService.GetUser(userLogin));
        }

        public async Task<bool> AddTrainerAsync(Trainer trainer)
        {
            return await _trainerService.AddTrainer(_mapper.MapTrainerToDomain(trainer));
        }

        public async Task<List<Trainer>> GetAllTrainersAsync()
        {
            List<Trainer> allTrainers = new List<Trainer>();
            foreach (var trainer in await _trainerService.GetAllTrainers())
            {
                allTrainers.Add(_mapper.MapTrainerToContract(trainer));
            }
            return allTrainers;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            return await _studentService.AddStudentAsync(_mapper.MapStudentToDomain(student));
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> allStudents = new List<Student>();
            foreach (var student in await _studentService.GetAllStudentsAsync())
            {
                allStudents.Add(_mapper.MapStudentToContract(student));
            }
            return allStudents;
        }

        public async Task<bool> AddCourseAsync(Course course)
        {
            return await _courseService.AddCourseAsync(_mapper.MapCourseToDomain(course));
        }
    }
}
