

using Domain.DTO;
using Domain.Models;
using Domain.RepositryInterfaces;
using Domain.Service.Interfaces;

namespace Domain.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository repository;

        public WorkerService(IWorkerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Worker>> AddPositionToWorker(int id, AddPositionToWorkerDTO positionDTO)
        {
            return await repository.AddPositionToWorker(id, positionDTO);
        }

        public async Task CreateAsync(CreateWorkerDTO workerDTO)
        {
            await repository.CreateAsync(workerDTO);
        }

        public async Task<IEnumerable<Worker>> DeleteAsync(int workerId)
        {
            return await repository.DeleteAsync(workerId);
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            return await repository.GetAllWorkersAsync();
        }

        public async Task<IEnumerable<Worker>> GetWorkerByIdAsync(int workerDTO)
        {
            return await repository.GetWorkersByIdAsync(workerDTO);
        }

        public async Task<Worker> GetWorkerByNameAsync(string workerName)
        {
            return await repository.GetWorkerByNameAsync(workerName);
        }

        public async Task<int> UpdateAsync(int id, CreateWorkerDTO workerDTO)
        {
            return await repository.UpdateAsync(id, workerDTO);
        }
    }
}
