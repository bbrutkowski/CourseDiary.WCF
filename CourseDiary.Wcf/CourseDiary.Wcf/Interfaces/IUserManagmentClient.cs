using CourseDiary.Wcf.Models;
using System.ServiceModel;

namespace CourseDiary.Wcf.Interfaces
{
    [ServiceContract]
    public interface IUserManagmentClient
    {
        [OperationContract]
        bool CheckUserCredentials(string userLogin, string userPassword);
       [OperationContract]
        User GetUser(string userLogin);
    }
}
