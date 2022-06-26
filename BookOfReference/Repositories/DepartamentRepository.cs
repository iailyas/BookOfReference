using BookOfReference.DTO;
using BookOfReference.Models;
using BookOfReference.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookOfReference.Repositories
{
    public class DepartamentRepository : IDepartamentRepository
    {
        private readonly ApplicationDBContext context;

        public DepartamentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Departament>> AddWorkerToDepartament(int id, CreateWorkerDTO workerDTO)
        {
            var departament = await GetDepartamentsByIdAsync(id);
            if (departament == null)
            {
                return null;
            }
            var worker = new Worker
            {
                FirstName = workerDTO.FirstName,
                LastName = workerDTO.LastName,
                Phone = workerDTO.Phone,
                DepartamentId = workerDTO.DepartamentId
            };



            await context.Workers.AddAsync(worker);
            await context.SaveChangesAsync();
            return await GetDepartamentsByIdAsync(id);
        }

        public async Task CreateAsync(CreateDepartamentDTO departamentDTO)
        {
            await context.AddAsync(departamentDTO);
            //var commandText = "INSERT INTO Departaments (DepartamentName,DepartamentPhone,City,Region,Adress,Phone,WorkersCount,CompanyId)" +
            //    " VALUES (@DepartamentName,@DepartamentPhone,@City,@Region,@Adress,@Phone,@WorkersCount,@CompanyId)";
            //var DepartamentName = new SqlParameter("@DepartamentName", departamentDTO.DepartamentName);
            //var DepartamentPhone = new SqlParameter("@DepartamentPhone", departamentDTO.DepartamentPhone);
            //var City = new SqlParameter("@City", departamentDTO.City);
            //var Region = new SqlParameter("@Region", departamentDTO.Region);
            //var Adress = new SqlParameter("@Adress", departamentDTO.Adress);
            //var Phone = new SqlParameter("@Phone", departamentDTO.Phone);
            //var WorkersCount = new SqlParameter("@WorkersCount", departamentDTO.WorkersCount);
            //var CompanyId = new SqlParameter("@CompanyId", departamentDTO.CompanyId);
            context.SaveChanges();
            ////return await context.Database.ExecuteSqlRawAsync(commandText, DepartamentName, DepartamentPhone, City, Region, Adress, Phone, WorkersCount, CompanyId);
        }

        public async Task<IEnumerable<Departament>> DeleteAsync(int departamentId)
        {
            var id = new SqlParameter("@id", departamentId);
            context.SaveChanges();
            return await context.Departaments
            .FromSqlRaw("DELETE FROM Departaments WHERE Id = @id", id).ToListAsync();


        }

        public async Task<IEnumerable<Departament>> GetAllDepartamentsAsync()
        {
            return await context.Departaments
           .FromSqlRaw("SELECT * FROM Departaments")
           .ToListAsync();
        }

        public async Task<IEnumerable<Departament>> GetDepartamentsByIdAsync(int departamentId)
        {
            var id = new SqlParameter("@Id", departamentId);
            return await context.Departaments
           .FromSqlRaw("SELECT * FROM Departaments WHERE Id = @id", id)
           .ToListAsync();
        }

        public Task<Departament> GetDepartamentsByNameAsync(string departamentName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(int id, CreateDepartamentDTO departamentDTO)
        {
            var commandText = "UPDATE Departaments SET DepartamentName = @DepartamentName, DepartamentPhone = @DepartamentPhone, City = @City, Region = @Region, Adress = @Adress," +
                "Phone=@Phone,WorkersCount=@WorkersCount,CompanyId=@CompanyId WHERE Id = @id";
            var DepartamentName = new SqlParameter("@DepartamentName", departamentDTO.DepartamentName);
            var DepartamentPhone = new SqlParameter("@DepartamentPhone", departamentDTO.DepartamentPhone);
            var City = new SqlParameter("@City", departamentDTO.City);
            var Region = new SqlParameter("@Region", departamentDTO.Region);
            var Adress = new SqlParameter("@Adress", departamentDTO.Adress);
            var Phone = new SqlParameter("@Phone", departamentDTO.Phone);
            var WorkersCount = new SqlParameter("@WorkersCount", departamentDTO.WorkersCount);
            var CompanyId = new SqlParameter("@CompanyId", departamentDTO.CompanyId);
            var Currentid = new SqlParameter("@id", id);
            context.SaveChanges();
            return await context.Database.ExecuteSqlRawAsync(commandText, DepartamentName, DepartamentPhone, City, Region, Adress, Phone, WorkersCount, CompanyId, Currentid);
        }
    }
}
