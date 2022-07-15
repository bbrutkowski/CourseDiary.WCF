using CourseDiary.Wcf.Domain;
using CourseDiary.Wcf.Domain.Models;
using CourseDiary.Wcf.Infrastructure;

namespace CourseDiary.Wcf.SelfhostServer
{
    public class CourseDiaryServiceDefinitions
    {
        private readonly UserService _userService;
        private readonly Mapper _mapper;

        public CourseDiaryServiceDefinitions()
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
            return _userService.GetUser(userLogin);
        }

    }
}
