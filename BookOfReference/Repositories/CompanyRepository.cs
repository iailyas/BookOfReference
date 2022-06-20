using BookOfReference.Interfaces;
using BookOfReference.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace BookOfReference.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDBContext context;

        public CompanyRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        

        public Task DeleteAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
           
                return await context.Companies
               .FromSqlRaw("SELECT * FROM Company")
               .ToListAsync();

            
        }

        //public async Task<Company> GetCompanyByIdAsync(int companyId, CancellationToken cancellationToken)
        //{
        //    //cancellationToken.ThrowIfCancellationRequested();
        //    //using (var connection = new SqlConnection(connectionString))
        //    //{
        //    //    await connection.OpenAsync(cancellationToken);
        //    //    return await connection<Company>($@"SELECT * FROM [ApplicationUser]
        //    //    WHERE [Id] = @{nameof(companyId)}", new { companyId });
        //    //}
        //}

        public Task<Company> GetCompanyByIdAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyByNameAsync(string companyName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Company company)
        {
            var commandText = "INSERT INTO COMPANY (Id,Name\",\"Phone\",\"Region\",\"City\",\"Adress\")" +
                " VALUES (@Id,\'@Name\',\'@Phone\',\'@Region\',\'@City\',\'@Adress\')";
            var Id = new SqlParameter("@Id", company.Id);
            var Name = new SqlParameter("@Name", company.Name);
            var Phone = new SqlParameter("@Phone", company.Phone);
            var Region = new SqlParameter("@Region", company.Region);
            var City = new SqlParameter("@City", company.City);
            var Adress = new SqlParameter("@Adress", company.Adress);
            // var Departaments = new SqlParameter("@Adress", company.Departaments);
           // context.Add(company);
            return await context.Database.ExecuteSqlRawAsync(commandText, Id, Name, Phone, Region, City, Adress);
        }
    }
}
