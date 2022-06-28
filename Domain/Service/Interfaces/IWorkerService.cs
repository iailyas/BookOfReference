
using Domain.DTO;
using Domain.Models;

namespace Domain.Service.Interfaces
{
    public interface IWorkerService
    {
        public Task CreateAsync(CreateWorkerDTO workerDTO);
        public Task<IEnumerable<Worker>> AddPositionToWorker(int id, AddPositionToWorkerDTO positionDTO);
        public Task<IEnumerable<Worker>> GetAllWorkersAsync();
        public Task<IEnumerable<Worker>> GetWorkerByIdAsync(int workerDTO);
        public Task<Worker> GetWorkerByNameAsync(string workerName);
        public Task<int> UpdateAsync(int id, CreateWorkerDTO workerDTO);
        public Task<IEnumerable<Worker>> DeleteAsync(int workerId);
    }
}
