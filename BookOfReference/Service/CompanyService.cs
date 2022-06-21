using BookOfReference.DTO;
using BookOfReference.Interfaces;
using BookOfReference.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookOfReference.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository repository;

        public CompanyService(ICompanyRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateAsync(CreateCompanyDTO companyDTO)
        {

            return await repository.CreateAsync(companyDTO);
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await repository.GetAllCompaniesAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanyByIdAsync(int companyId)
        {
            return await repository.GetCompanyByIdAsync(companyId);
        }

        public Task<Company> GetCompanyByNameAsync(string companyName)
        {
            throw new NotImplementedException();
        }
        public async Task<int> UpdateAsync(int id, CreateCompanyDTO companyDTO)
        {
            return await repository.UpdateAsync(id, companyDTO);
        }

        public Task<IEnumerable<Company>> DeleteAsync(int companyId)
        {
            return repository.DeleteAsync(companyId);
        }
    }
}
