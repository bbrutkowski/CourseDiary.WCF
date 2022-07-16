using CourseDiary.Wcf.ServiceDefinitions.Interfaces;
using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.Client.Managments
{
    public class TrainerManagmentClient : ClientBase<ITrainerManagmentService>
    {
        public async Task<bool> AddTrainerAsync(Trainer trainer)
        {
            return await Channel.AddTrainerAsync(trainer);
        }

        public async Task<List<Trainer>> GetAllTrainersAsync()
        {
            return await Channel.GetAllTrainersAsync();
        }

    }
}
