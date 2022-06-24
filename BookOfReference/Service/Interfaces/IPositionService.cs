using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Service.Interfaces
{
    public interface IPositionService
    {
        public Task<int> CreateAsync(CreatePositionDTO positionDTO);
        public Task<IEnumerable<Position>> GetAllPositionsAsync();
        public Task<IEnumerable<Position>> GetPositionsByIdAsync(int positionId);
        public Task<Position> GetPositionsByNameAsync(string positionName);
        public Task<int> UpdateAsync(int id, CreatePositionDTO positionDTO);
        public Task<IEnumerable<Position>> DeleteAsync(int positionId);
    }
}
