using CourseDiary.Wcf.Client.Clients;
using CourseDiary.Wcf.Models;
using System;

namespace CourseDiary.Wcf.Client
{
    public class LoginHelper
    {
        private readonly Interactions _interactions;
        private readonly UserManagmentClient _userManagmentClient;

        public LoginHelper()
        {
            _interactions = new Interactions();
            _userManagmentClient = new UserManagmentClient();
        }

        public User LoginLoop()
        {
            bool exit = false;
            User user = null;

            while (!exit)
            {
                user = LoginUser();
                if (user != null)
                {
                    break;
                }
            }
            return user;
        }

        public User LoginUser()
        {
            User newUser = new User();
            string userLogin = _interactions.GetInfoFromUser("Enter user's login");
            string userPassword = _interactions.GetInfoFromUser("Enter user's password");

            bool correctCredentials = _userManagmentClient.LoginUser(userLogin, userPassword);

            if (correctCredentials == true)
            {
                Console.WriteLine($"Login successful. Hello {userLogin}!");
            }
            else if (correctCredentials == false)
            {
                Console.WriteLine($"The user not found. Register new user");
                LoginUser();
            }

            newUser = _userManagmentClient.GetUser(userLogin);

            return newUser;
        }
    }
}
