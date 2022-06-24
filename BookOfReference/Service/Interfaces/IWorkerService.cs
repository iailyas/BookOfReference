using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Service.Interfaces
{
    public interface IWorkerService
    {
        public Task<int> CreateAsync(CreateWorkerDTO workerDTO);
        public Task<IEnumerable<Worker>> GetAllWorkersAsync();
        public Task<IEnumerable<Worker>> GetWorkerByIdAsync(int workerDTO);
        public Task<Worker> GetWorkerByNameAsync(string workerName);
        public Task<int> UpdateAsync(int id, CreateWorkerDTO workerDTO);
        public Task<IEnumerable<Worker>> DeleteAsync(int workerId);
    }
}
