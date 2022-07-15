using CourseDiary.Wcf.Interfaces;
using CourseDiary.Wcf.Models;
using System.ServiceModel;

namespace CourseDiary.Wcf.Client.Clients
{
    public class UserManagmentClient : ClientBase<IUserManagmentClient>
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
