using CourseDiary.Wcf.Domain.Interfaces;
using CourseDiary.Wcf.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Domain
{
    public interface ITrainerService
    {
        Task<bool> AddTrainer(Trainer trainer);
        Task<List<Trainer>> GetAllTrainers();
    }

    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public async Task<bool> AddTrainer(Trainer trainer)
        {
            return await _trainerRepository.AddTrainer(trainer);
        }

        public async Task<List<Trainer>> GetAllTrainers()
        {
            return await _trainerRepository.GetAllTrainers();
        }
    }
}
