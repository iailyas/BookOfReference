using BookOfReference.Models;

namespace BookOfReference.Interfaces
{
    public interface ICompanyRepository
    {
        public  Task<IEnumerable<Company>> GetAllCompaniesAsync();
        public  Task<int> CreateAsync(Company company);
        public  Task<Company> GetCompanyByIdAsync(int companyId);
        public  Task<Company> GetCompanyByNameAsync(string companyName);
        public  Task UpdateAsync(Company company);
        public  Task DeleteAsync(int companyId);

    }
}
