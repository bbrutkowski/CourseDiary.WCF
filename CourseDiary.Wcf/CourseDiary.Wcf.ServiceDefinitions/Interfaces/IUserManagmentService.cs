using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.ServiceModel;

namespace CourseDiary.Wcf.ServiceDefinitions.Interfaces
{
    [ServiceContract]
    public interface IUserManagmentService
    {
        [OperationContract]
        bool CheckUserCredentials(string userLogin, string userPassword);
        [OperationContract]
        User GetUser(string userLogin);
    }
}
