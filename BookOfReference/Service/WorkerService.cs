using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Service
{
    public class WorkerService : IWorkerService
    {
        public Task<int> CreateAsync(CreateWorkerDTO workerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Worker>> DeleteAsync(int workerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Worker>> GetWorkerByIdAsync(int workerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Worker> GetWorkerByNameAsync(string workerName)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, CreateWorkerDTO workerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
