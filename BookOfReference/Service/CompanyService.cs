using BookOfReference.DTO;
using BookOfReference.Interfaces;
using BookOfReference.Models;

namespace BookOfReference.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository repository;

        public CompanyService(ICompanyRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(CreateCompanyDTO companyDTO)
        {

            await repository.CreateAsync(companyDTO);
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await repository.GetAllCompaniesAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanyByIdAsync(int companyId)
        {
            return await repository.GetCompanyByIdAsync(companyId);
        }

        public async Task<IEnumerable<Company>> GetCompanyByNameAsync(string companyName)
        {
            return await repository.GetCompanyByNameAsync(companyName);
        }
        public async Task<int> UpdateAsync(int id, CreateCompanyDTO companyDTO)
        {
            return await repository.UpdateAsync(id, companyDTO);
        }

        public Task<IEnumerable<Company>> DeleteAsync(int companyId)
        {
            return repository.DeleteAsync(companyId);
        }

        public async Task<IEnumerable<Company>> AddDepartamentToCompany(int id, AddDepartamentToCompanyDTO addDepartament)
        {
            return await repository.AddDepartamentToCompany(id, addDepartament);
        }
    }
}
