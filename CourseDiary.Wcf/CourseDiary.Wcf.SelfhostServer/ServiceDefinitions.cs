using CourseDiary.Wcf.Domain;
using CourseDiary.Wcf.Infrastructure;
using CourseDiary.Wcf.ServiceDefinitions.Interfaces;
using CourseDiary.Wcf.ServiceDefinitions.Models;

namespace CourseDiary.Wcf.SelfhostServer
{
    public class ServiceDefinitions : IUserManagmentService
    {
        private readonly UserService _userService;
        private readonly Mapper _mapper;

        public ServiceDefinitions()
        {
            _userService = new UserService(new UserRepository());
            _mapper = new Mapper();
        }
        public bool CheckUserCredentials(string userLogin, string userPassword)
        {
            return _userService.CheckUserCredentials(userLogin, userPassword);
        }

        public User GetUser(string userLogin)
        {
            return _mapper.MapUserToContract(_userService.GetUser(userLogin));
        }

    }
}
