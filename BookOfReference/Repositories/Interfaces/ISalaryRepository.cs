using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Repositories.Interfaces
{
    public interface ISalaryRepository
    {
        public Task CreateAsync(CreateSalaryDTO salaryDTO);
        //public Task<IEnumerable<Salary>> AddPositionToSalary(int id, AddPositionToSalaryDTO positionDTO);
        public Task<IEnumerable<Salary>> GetAllSalaryAsync();
        public Task<IEnumerable<Salary>> GetSalaryByIdAsync(int salaryId);
        public Task<Salary> GetSalaryByNameAsync(string salaryName);
        public Task<int> UpdateAsync(int id, CreateSalaryDTO salaryDTO);
        public Task<IEnumerable<Salary>> DeleteAsync(int salaryId);
    }
}
