using BookOfReference.DTO;
using BookOfReference.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookOfReference.Interfaces
{
    public interface ICompanyRepository
    {
        public Task CreateAsync(CreateCompanyDTO company);
        public Task<IEnumerable<Company>> GetAllCompaniesAsync();        
        public Task<IEnumerable<Company>> GetCompanyByIdAsync(int companyId);
        public Task<IEnumerable<Company>> GetCompanyByNameAsync(string companyName);
        public Task<int> UpdateAsync(int id, CreateCompanyDTO companyDTO);
        public Task<IEnumerable<Company>> AddDepartamentToCompany(int id, AddDepartamentToCompanyDTO addDepartament);
        public Task<IEnumerable<Company>> DeleteAsync(int companyId);

    }
}
