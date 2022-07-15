using CourseDiary.Wcf.Domain.Models;
using WcfUser = CourseDiary.Wcf.Models.User;

namespace CourseDiary.Wcf.SelfhostServer
{
    public class Mapper
    {
        public WcfUser MapUserToContract(User user)
        {
            return new WcfUser()
            {
                Name = user.Login,
                Password = user.Password,
                Role = user.Role,
            };
        }
    }
}
