using CourseDiary.Wcf.Client.Managments;
using CourseDiary.Wcf.ServiceDefinitions.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseDiary.Wcf.Client
{
    internal class Program
    {
        private readonly LoginHelper _loginHelper;
        private User _loggedUser;
        private readonly Interactions _interactions;
        private readonly Menu _menu;
        private readonly TrainerManagmentClient _trainerMenagmentClient;
        private readonly StudentManagmentClient _studentManagmentClient;
        private readonly CourseManagmentClient _courseManagmentClient;
        public Program()
        {
            _loginHelper = new LoginHelper();
            _loggedUser = new User();
            _interactions = new Interactions();
            _menu = new Menu();
            _trainerMenagmentClient = new TrainerManagmentClient();
            _studentManagmentClient = new StudentManagmentClient();
            _courseManagmentClient = new CourseManagmentClient();

        }
        static void Main(string[] args)
        {
            new Program().Run();

        }

        private void Run()
        {
            Console.WriteLine("Welcome! You must log in before selecting an action. Please enter your user name and password.");

            var user = _loginHelper.LoginLoop();
            if (user != null)
            {
                ProgramLoop(user);
            }
        }

        public void ProgramLoop(User loggedUser)
        {
            RegisterMenuCommands();
            _loggedUser = loggedUser;
            //_userManager.SetLoggedUser(loggedUser);
            //_inspections.SetLoggedUser(loggedUser);

            bool exit = false;
            while (!exit)
            {
                _menu.PrintAllCommands();

                int commandId = _interactions.GetIntFromUser("Select command");

                try
                {
                    _menu.ExecuteCommand(commandId);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error while executing {commandId} command: {e.Message}");
                }
            }
        }

        private void RegisterMenuCommands()
        {
            _menu.Register(1, new MenuItem { Action = AddTrainer, Name = "Add new trainer", Description = "Adding a new trainer to the system" });
            _menu.Register(2, new MenuItem { Action = AddStudent, Name = "Add new student", Description = "Adding a new student to the system" });
            _menu.Register(3, new MenuItem { Action = AddCourse, Name = "Add new course", Description = "Adding a new course to system" });         
        }

        private async void AddCourse()
        {
            List<Trainer> trainers = await _trainerMenagmentClient.GetAllTrainersAsync();
            List<Student> students = await _studentManagmentClient.GetAllStudentsAsync();
            Course newCourse = new Course();
            newCourse.Name = _interactions.GetInfoFromUser("Course name: ");
            newCourse.BeginDate = _interactions.GetDateFromUser("Begin date(dd/mm/yyyy): ");
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Id}. {trainer.Name} {trainer.Surname} - {trainer.Email}");
            }
            newCourse.Trainer = trainers.Where(x => x.Id == _interactions.GetIntFromUser("Choose id of trainer: ")).ToList()[0];
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id}. {student.Name} {student.Surname} - {student.Email}");
            }
            var idList = _interactions.GetStudentIds();
            newCourse.Students = students.Where(x => idList.Contains(x.Id)).ToList();

            await _courseManagmentClient.AddCourseAsync(newCourse);

        }

        private async void AddStudent()
        {
            Student newStudent = new Student()
            {
                Name = _interactions.GetInfoFromUser("Enter students name"),
                Surname = _interactions.GetInfoFromUser("Enter trainers surname"),
                Email = _interactions.GetInfoFromUser("Select trainers email"),
                Password = _interactions.GetInfoFromUser("Enter trainer password. Min 6 signs"),
                BirthDate = DateTime.Parse(_interactions.GetInfoFromUser("Enter date of birth")),
            };
            await _studentManagmentClient.AddStudentAsync(newStudent);
        }

        private async void AddTrainer()
        {
            Trainer newTrainer = new Trainer()
            { 
                Name = _interactions.GetInfoFromUser("Enter trainers name"),
                Surname = _interactions.GetInfoFromUser("Enter trainers surname"),
                Email = _interactions.GetInfoFromUser("Select trainers email"),
                Password = _interactions.GetInfoFromUser("Enter trainer password. Min 6 signs"),
                DateOfBirth = DateTime.Parse(_interactions.GetInfoFromUser("Enter date of birth")),
            };
            await _trainerMenagmentClient.AddTrainerAsync(newTrainer);
        }
    }
}
