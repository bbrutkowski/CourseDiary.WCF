using CourseDiary.Wcf.ServiceDefinitions.Models;
using System;

namespace CourseDiary.Wcf.Client
{
    internal class Program
    {
        private readonly LoginHelper _loginHelper;
        private User _loggedUser;
        private readonly Interactions _interactions;
        private readonly Menu _menu;
        public Program()
        {
            _loginHelper = new LoginHelper();
            _loggedUser = new User();
            _interactions = new Interactions();
            _menu = new Menu();
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
            //_menu.Register(1, new MenuItem { Action = _userManager.AddUser, Name = "Add new user", Description = "Adding a new user with guest or administrator attributes" });
            //_menu.Register(2, new MenuItem { Action = _userManager.DeleteUser, Name = "Delete user", Description = "Removing a user" });
            //_menu.Register(3, new MenuItem { Action = _powerPlantManager.InitTimer, Name = "Show work of power plants", Description = "Displays the work of power plants" });
            //_menu.Register(4, new MenuItem { Action = _anomalies.GetAnomalies, Name = "Retrieving information about anomaly", Description = "Displays all anomalies at the time specified by user" });
            //_menu.Register(5, new MenuItem { Action = _anomalies.AnomalyStatistics, Name = "View anomaly statistics", Description = "Displays anomaly statistics for a given user specified of time" });
            //_menu.Register(6, new MenuItem { Action = _inspections.AddNewInspection, Name = "Adding device inspection", Description = "Allows you to add new inspection" });
            //_menu.Register(7, new MenuItem { Action = _inspections.GetAllInspections, Name = "Download all inspections", Description = "Gets information about all planned inspections" });
            //_menu.Register(8, new MenuItem { Action = _inspections.UpdateInspection, Name = "Assign engineer to inspection", Description = "Assigns a logged engineer to selected inspection" });
            //_menu.Register(9, new MenuItem { Action = _inspections.GettAllEngineerInspections, Name = "View inspections for assigned engineers", Description = "Displays all inspections with assigned engineers" });
        }
    }
}
