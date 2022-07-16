using CourseDiary.Wcf.Domain.Models;
using WcfUser = CourseDiary.Wcf.ServiceDefinitions.Models.User;
using WcfTrainer = CourseDiary.Wcf.ServiceDefinitions.Models.Trainer;
using WcfStudent = CourseDiary.Wcf.ServiceDefinitions.Models.Student;
using WcfCourse = CourseDiary.Wcf.ServiceDefinitions.Models.Course;
using System.Collections.Generic;

namespace CourseDiary.Wcf.SelfhostServer
{
    public class Mapper
    {
        public WcfUser MapUserToContract(User user)
        {
            return new WcfUser()
            {
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,
            };
        }

        public Trainer MapTrainerToDomain(WcfTrainer wcftrainer)
        {
            return new Trainer()
            {
                Name = wcftrainer.Name,
                Surname = wcftrainer.Surname,
                Password = wcftrainer.Password,
                Email = wcftrainer.Email,
                DateOfBirth = wcftrainer.DateOfBirth,
            };
        }

        public WcfTrainer MapTrainerToContract(Trainer trainer)
        {
            return new WcfTrainer()
            {
                Name = trainer.Name,
                Surname = trainer.Surname,
                Password = trainer.Password,
                Email = trainer.Email,
                DateOfBirth = trainer.DateOfBirth,
                Id = trainer.Id
            };
        }

        public WcfStudent MapStudentToContract(Student student)
        {
            return new WcfStudent()
            {
                Name = student.Name,
                Surname = student.Surname,
                Email = student.Email,
                Password = student.Password,
                BirthDate = student.BirthDate
            };
        }

        public Student MapStudentToDomain(WcfStudent wcfStudent)
        {
            return new Student()
            {
                Name = wcfStudent.Name,
                Surname = wcfStudent.Surname,
                Email = wcfStudent.Email,
                Password = wcfStudent.Password,
                BirthDate = wcfStudent.BirthDate
            };
        }

        public List<Student> MapListOfStudentsToDomain(WcfStudent wcfstudent)
        {
            List<Student> students = new List<Student>();
            foreach (var student in students)
            {
                student.Name = wcfstudent.Name;
                student.Surname = wcfstudent.Surname;
                student.Email = wcfstudent.Email;
                student.Password = wcfstudent.Password;
                student.BirthDate = wcfstudent.BirthDate;
                students.Add(student);
            }
            return students;
        }

        public Course MapCourseToDomain(WcfCourse wcfcourse)
        {
            return new Course()
            {
                Name = wcfcourse.Name,
                Trainer = MapTrainerToDomain(wcfcourse.Trainer),
                HomeworkTreshold = wcfcourse.HomeworkTreshold,
                BeginDate = wcfcourse.BeginDate,
                Id = wcfcourse.Id,
                PresenceTreshold = wcfcourse.PresenceTreshold,
                TestTreshold = wcfcourse.TestTreshold,           
            };
        }
    }
}
