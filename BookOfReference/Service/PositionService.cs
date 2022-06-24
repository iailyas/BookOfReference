using BookOfReference.DTO;
using BookOfReference.Models;
using BookOfReference.Repositories.Interfaces;

namespace BookOfReference.Service
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository repository;
        public PositionService(IPositionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateAsync(CreatePositionDTO positionDTO)
        {
            return await repository.CreateAsync(positionDTO);
        }

        public async  Task<IEnumerable<Position>> DeleteAsync(int positionId)
        {
            return await repository.DeleteAsync(positionId);
        }

        public async  Task<IEnumerable<Position>> GetAllPositionsAsync()
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
