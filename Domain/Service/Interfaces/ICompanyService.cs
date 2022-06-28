

using Domain.DTO;
using Domain.Models;

namespace Domain.Service.Interfaces
{
    public interface ICompanyService
    {
        public Task CreateAsync(CreateCompanyDTO companyDTO);
        public Task<IEnumerable<Company>> GetAllCompaniesAsync();
        public Task<IEnumerable<Company>> GetCompanyByIdAsync(int companyId);
        public Task<IEnumerable<Company>> GetCompanyByNameAsync(string companyName);
        public Task<IEnumerable<Company>> AddDepartamentToCompany(int id, AddDepartamentToCompanyDTO addDepartament);
        public Task<int> UpdateAsync(int id, CreateCompanyDTO companyDTO);
        public Task<IEnumerable<Company>> DeleteAsync(int companyId);
    }
}
