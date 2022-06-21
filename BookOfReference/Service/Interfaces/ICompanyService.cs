using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Service.Interfaces
{
    public interface ICompanyService
    {
        public Task<int> CreateAsync(CreateCompanyDTO companyDTO);
        public Task<IEnumerable<Company>> GetAllCompaniesAsync();        
        public Task<IEnumerable<Company>> GetCompanyByIdAsync(int companyId);
        public Task<Company> GetCompanyByNameAsync(string companyName);
        public Task<int> UpdateAsync(int id, CreateCompanyDTO companyDTO);
        public Task<IEnumerable<Company>> DeleteAsync(int companyId);
    }
}
