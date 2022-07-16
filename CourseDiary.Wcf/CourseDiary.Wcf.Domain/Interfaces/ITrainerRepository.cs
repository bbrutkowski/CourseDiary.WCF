using CourseDiary.Wcf.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Domain.Interfaces
{
    public interface ITrainerRepository
    {
        Task<bool> AddTrainer(Trainer trainer);
        Task<List<Trainer>> GetAllTrainers();
    }
}
