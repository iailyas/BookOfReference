using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Repositories.Interfaces
{
    public interface IWorkerRepository
    {
        public Task<int> CreateAsync(CreateWorkerDTO workerDTO);
        public Task<IEnumerable<Worker>> GetAllWorkersAsync();
        public Task<IEnumerable<Worker>> GetWorkersByIdAsync(int workerDTO);
        public Task<Worker> GetWorkerByNameAsync(string workerName);
        public Task<int> UpdateAsync(int id, CreateWorkerDTO workerDTO);
        public Task<IEnumerable<Worker>> DeleteAsync(int workerId);
    }
}
