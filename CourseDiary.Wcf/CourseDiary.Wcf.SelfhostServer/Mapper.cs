using CourseDiary.Wcf.Domain.Models;
using WcfUser = CourseDiary.Wcf.ServiceDefinitions.Models.User;


namespace CourseDiary.Wcf.SelfhostServer
{
    public class Mapper
    {
        public WcfUser MapUserToContract(User user)
        {
            return new WcfUser()
            {
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,
            };
        }
    }
}
