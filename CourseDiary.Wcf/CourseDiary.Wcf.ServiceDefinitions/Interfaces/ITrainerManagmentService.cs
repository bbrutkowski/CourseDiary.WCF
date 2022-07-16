using CourseDiary.Wcf.ServiceDefinitions.Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.ServiceDefinitions.Interfaces
{
    [ServiceContract]
    public interface ITrainerManagmentService
    {
        [OperationContract]
        Task<bool> AddTrainerAsync(Trainer trainer);
        [OperationContract]
        Task<List<Trainer>> GetAllTrainersAsync();

    }
}
