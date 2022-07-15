using CourseDiary.Wcf.Domain.Models;

namespace CourseDiary.Wcf.Domain.Interfaces
{
    public interface IUserRepository
    {
       User GetUser(string userLogin);
    }
}
