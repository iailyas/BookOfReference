﻿using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        public Task<int> CreateAsync(CreatePositionDTO positionDTO);
        public Task<IEnumerable<Position>> GetAllPositionsAsync();
        public Task<IEnumerable<Position>> GetPositionsByIdAsync(int positionId);
        public Task<Position> GetPositionsByNameAsync(string positionName);
        public Task<int> UpdateAsync(int id, CreatePositionDTO positionDTO);
        public Task<IEnumerable<Position>> DeleteAsync(int positionId);
    }
}
