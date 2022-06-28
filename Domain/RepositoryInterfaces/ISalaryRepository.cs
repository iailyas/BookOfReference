
using Domain.DTO;
using Domain.Models;

namespace Domain.RepositryInterfaces
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
