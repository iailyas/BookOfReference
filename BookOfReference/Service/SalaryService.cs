using BookOfReference.DTO;
using BookOfReference.Models;
using BookOfReference.Repositories.Interfaces;

namespace BookOfReference.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository repository;

        public SalaryService(ISalaryRepository repository)
        {
            this.repository = repository;
        }

        //public async Task AddPositionToSalary(int id, AddPositionToSalaryDTO positionDTO)
        //{
        //    await repository.AddPositionToSalary(id,positionDTO);
        //}

        public async Task CreateAsync(CreateSalaryDTO salaryDTO)
        {
            await repository.CreateAsync(salaryDTO);
        }

        public async Task<IEnumerable<Salary>> DeleteAsync(int salaryId)
        {
            return await repository.DeleteAsync(salaryId);
        }

        public async Task<IEnumerable<Salary>> GetAllSalaryAsync()
        {
            return await repository.GetAllSalaryAsync();
        }

        public async Task<IEnumerable<Salary>> GetSalaryByIdAsync(int salaryId)
        {
            return await repository.GetSalaryByIdAsync(salaryId);
        }

        public async Task<Salary> GetSalaryByNameAsync(string salaryName)
        {
            return await repository.GetSalaryByNameAsync(salaryName);
        }

        public async Task<int> UpdateAsync(int id, CreateSalaryDTO salaryDTO)
        {
            return await repository.UpdateAsync(id, salaryDTO);
        }
    }
}
