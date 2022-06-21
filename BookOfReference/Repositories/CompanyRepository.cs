using BookOfReference.DTO;
using BookOfReference.Interfaces;
using BookOfReference.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace BookOfReference.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDBContext context;

        public CompanyRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Company>> DeleteAsync(int companyId)
        {

            var id = new SqlParameter("@id", companyId);
            
            return await context.Companies
            .FromSqlRaw("DELETE FROM Companies WHERE Id = @id", id).ToListAsync();
            context.SaveChanges();
            
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await context.Companies
           .FromSqlRaw("SELECT * FROM Companies")
           .ToListAsync();
        }
        public async Task<IEnumerable<Company>> GetCompanyByIdAsync(int companyId)
        {
            var id = new SqlParameter("@Id", companyId);
            return await context.Companies
           .FromSqlRaw("SELECT * FROM Companies WHERE Id = @id", id)
           .ToListAsync();
        }
        public Task<Company> GetCompanyByNameAsync(string companyName)
        {
            throw new NotImplementedException();
        }
        public async Task<int> CreateAsync(CreateCompanyDTO companyDTO)
        {

            var commandText = "INSERT INTO COMPANIES (Name,Phone,Region,City,Adress)" +
                " VALUES (@Name,@Phone,@Region,@City,@Adress)";
            var Name = new SqlParameter("@Name", companyDTO.Name);
            var Phone = new SqlParameter("@Phone", companyDTO.Phone);
            var Region = new SqlParameter("@Region", companyDTO.Region);
            var City = new SqlParameter("@City", companyDTO.City);
            var Adress = new SqlParameter("@Adress", companyDTO.Adress);
            context.SaveChanges();
            return await context.Database.ExecuteSqlRawAsync(commandText, Name, Phone, Region, City, Adress);

        }

        public Task<int> UpdateAsync(int id, CreateCompanyDTO companyDTO)
        {
            var commandText = "UPDATE Companies SET Name = @Name, Phone = @Phone, Region = @Region, City = @City, Adress = @Adress WHERE Id = @id";
            var Name = new SqlParameter("@Name", companyDTO.Name);
            var Phone = new SqlParameter("@Phone", companyDTO.Phone);
            var Region = new SqlParameter("@Region", companyDTO.Region);
            var City = new SqlParameter("@City", companyDTO.City);
            var Adress = new SqlParameter("@Adress", companyDTO.Adress);
            var Currentid = new SqlParameter("@id", id);
            context.SaveChanges();
            return context.Database.ExecuteSqlRawAsync(commandText, Name, Phone, Region, City, Adress, Currentid);
        }
    }
}
