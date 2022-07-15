using CourseDiary.Wcf.Domain.Interfaces;
using CourseDiary.Wcf.Domain.Models;

namespace CourseDiary.Wcf.Domain
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CheckUserCredentials(string userLogin, string userPassword)
        {
            User user = _userRepository.GetUser(userLogin);

            return user != null && user.Password == userPassword;
        }

        public User GetUser(string userLogin)
        {
            User user = _userRepository.GetUser(userLogin);
            return user;
        }

    }
}
