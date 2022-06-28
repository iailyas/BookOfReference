

using Domain.DTO;
using Domain.Models;
using Domain.RepositryInterfaces;
using Domain.Service.Interfaces;

namespace Domain.Service
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository repository;
        public PositionService(IPositionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Position>> AddSalaryToPosition(int id, CreateSalaryDTO salaryDTO)
        {
            return await repository.AddSalaryToPosition(id, salaryDTO);
        }

        //public async Task<IEnumerable<Position>> AddWorkerToPosition(int id, AddWorkerToPositionDTO workerDTO)
        //{
        //    return await repository.AddWorkerToPosition(id, workerDTO);
        //}

        public async Task CreateAsync(CreatePositionDTO positionDTO)
        {
            await repository.CreateAsync(positionDTO);
        }

        public async Task<IEnumerable<Position>> DeleteAsync(int positionId)
        {
            return await repository.DeleteAsync(positionId);
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await repository.GetAllPositionsAsync();
        }

        public async Task<IEnumerable<Position>> GetPositionsByIdAsync(int positionId)
        {
            return await repository.GetPositionsByIdAsync(positionId);
        }

        public async Task<Position> GetPositionsByNameAsync(string positionName)
        {
            return await repository.GetPositionsByNameAsync(positionName);
        }

        public async Task<int> UpdateAsync(int id, CreatePositionDTO positionDTO)
        {
            return await repository.UpdateAsync(id, positionDTO);
        }
    }
}
