using CourseDiary.Wcf.Models;
using System;

namespace CourseDiary.Wcf.Client
{
    internal class Program
    {
        private readonly Interactions _interactions;
        private User _loggedUser;
        private readonly LoginHelper _loginHelper;
        private readonly Menu _menu;
        public Program()
        {
            _interactions = new Interactions();
            _loggedUser = new User();
            _loginHelper = new LoginHelper();
            _menu = new Menu();
        }
        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            Console.WriteLine("Hello! Please log in first");
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
            
        }
    }
}
