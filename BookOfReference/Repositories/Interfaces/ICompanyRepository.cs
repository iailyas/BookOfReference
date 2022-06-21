using BookOfReference.DTO;
using BookOfReference.Models;

namespace BookOfReference.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetAllCompaniesAsync();
        public Task<int> CreateAsync(CreateCompanyDTO company);
        public Task<IEnumerable<Company>> GetCompanyByIdAsync(int companyId);
        public Task<Company> GetCompanyByNameAsync(string companyName);
        public Task<int> UpdateAsync(int id, CreateCompanyDTO companyDTO);
        public Task<IEnumerable<Company>> DeleteAsync(int companyId);

    }
}
