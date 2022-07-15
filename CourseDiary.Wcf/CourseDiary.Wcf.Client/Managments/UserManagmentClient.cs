using CourseDiary.Wcf.ServiceDefinitions.Interfaces;
using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.ServiceModel;

namespace CourseDiary.Wcf.Client.Managments
{
    public class UserManagmentClient : ClientBase<IUserManagmentService>
    {
        public bool LoginUser(string userLogin, string userPassword)
        {
            return Channel.CheckUserCredentials(userLogin, userPassword);
        }

        public User GetUser(string UserLogin)
        {
            return Channel.GetUser(UserLogin);
        }
    }
}
