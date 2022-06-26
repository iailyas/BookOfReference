using BookOfReference.DTO;
using BookOfReference.Interfaces;
using BookOfReference.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace BookOfReference.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDBContext context;

        public CompanyRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(CreateCompanyDTO companyDTO)
        {
            var company = new Company
            {
                Name = companyDTO.Name,
                Region = companyDTO.Region,
                Adress = companyDTO.Adress,
                City = companyDTO.City,
                Phone = companyDTO.Phone
            };
            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();
            //var commandText = "INSERT INTO Companies (Name,Phone,Region,City,Adress)" +
            //    " VALUES (@Name,@Phone,@Region,@City,@Adress)";
            //var Name = new SqlParameter("@Name", companyDTO.Name);
            //var Phone = new SqlParameter("@Phone", companyDTO.Phone);
            //var Region = new SqlParameter("@Region", companyDTO.Region);
            //var City = new SqlParameter("@City", companyDTO.City);
            //var Adress = new SqlParameter("@Adress", companyDTO.Adress);

            // return await context.Database.ExecuteSqlRawAsync(commandText, Name, Phone, Region, City, Adress);

        }
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await context.Companies
                .FromSqlRaw("SELECT * FROM Companies")
                .Include(c => c.Departaments)
                .ToListAsync();            
            
        }
        public async Task<IEnumerable<Company>> GetCompanyByIdAsync(int companyId)
        {
            var id = new SqlParameter("@Id", companyId);
            return await  context.Companies
           .FromSqlRaw("SELECT * FROM Companies WHERE Id = @id", id)
           .Include(c=>c.Departaments).ToListAsync();
        }
        public async Task<IEnumerable<Company>> GetCompanyByNameAsync(string companyName)
        {
            var Name = new SqlParameter("@Name", companyName);
            return await context.Companies
           .FromSqlRaw("SELECT * FROM Companies WHERE Name = @Name", Name)
           .Include(c => c.Departaments)
           .ToListAsync();
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
        public async Task<IEnumerable<Company>> DeleteAsync(int companyId)
        {

            var id = new SqlParameter("@id", companyId);

            return await context.Companies
            .FromSqlRaw("DELETE FROM Companies WHERE Id = @id", id).ToListAsync();
            context.SaveChanges();

        }

        public async Task<IEnumerable<Company>> AddDepartamentToCompany(int id, AddDepartamentToCompanyDTO addDepartament)
        {
            var company = await GetCompanyByIdAsync(id);
            if (company == null)
            {
                return null;
            }
            var Departament = new Departament
            {
                DepartamentName = addDepartament.DepartamentName,
                DepartamentPhone = addDepartament.DepartamentPhone,
                City = addDepartament.City,
                Region = addDepartament.Region,
                Adress = addDepartament.Adress,
                Phone = addDepartament.Phone,
                WorkersCount = addDepartament.WorkersCount,
                CompanyId = addDepartament.CompanyId
            };
           
           
            
            await context.Departaments.AddAsync(Departament);
            await context.SaveChangesAsync();
            return await GetCompanyByIdAsync(id);
            // var Id = new SqlParameter("@Id", id);
            // if (await context.Companies
            //.FromSqlRaw("SELECT * FROM Companies WHERE Id = @id", Id)
            //.ToListAsync() != null)
            // {
            //     var commandText = "INSERT INTO Departaments (DepartamentName,DepartamentPhone,City,Region,Adress,Phone,WorkersCount,CompanyId)" +
            //     " VALUES (@DepartamentName,@DepartamentPhone,@City,@Region,@Adress,@Phone,@WorkersCount,@CompanyId)";
            //     var DepartamentName = new SqlParameter("@DepartamentName", addDepartament.DepartamentName);
            //     var DepartamentPhone = new SqlParameter("@DepartamentPhone", addDepartament.DepartamentPhone);
            //     var City = new SqlParameter("@City", addDepartament.City);
            //     var Region = new SqlParameter("@Region", addDepartament.Region);
            //     var Adress = new SqlParameter("@Adress", addDepartament.Adress);
            //     var Phone = new SqlParameter("@Phone", addDepartament.Phone);
            //     var WorkersCount = new SqlParameter("@WorkersCount", addDepartament.WorkersCount);
            //     var CompanyId = new SqlParameter("@CompanyId", id);
            //     context.SaveChanges();
            //     return await context.Database.ExecuteSqlRawAsync(commandText, DepartamentName, DepartamentPhone, City, Region, Adress, Phone, WorkersCount, CompanyId);



        }
    }
}
