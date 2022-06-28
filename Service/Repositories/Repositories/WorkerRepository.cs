
using Domain.DTO;
using Domain.Models;
using Domain.RepositryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Service.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly ApplicationDBContext context;

        public WorkerRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(CreateWorkerDTO workerDTO)
        {
            await context.AddAsync(workerDTO);
            //var commandText = "INSERT INTO Workers (MonthSalary,AwardSalary,PositionId)" +
            //   " VALUES (@MonthSalary,@AwardSalary,@PositionId)";
            //var FirstName = new SqlParameter("@MonthSalary", workerDTO.FirstName);
            //var LastName = new SqlParameter("@AwardSalary", workerDTO.LastName);
            //var Phone = new SqlParameter("@PositionId", workerDTO.Phone);
            //var DepartamentId = new SqlParameter("@MonthSalary", workerDTO.DepartamentId);

            context.SaveChanges();
            //return await context.Database.ExecuteSqlRawAsync(commandText, FirstName, LastName, Phone, DepartamentId);
        }

        public async Task<IEnumerable<Worker>> DeleteAsync(int workerId)
        {
            var id = new SqlParameter("@id", workerId);
            context.SaveChanges();
            return await context.Workers
            .FromSqlRaw("DELETE FROM Workers WHERE Id = @id", id).ToListAsync();
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            return await context.Workers
            .FromSqlRaw("SELECT * FROM Workers")
            .ToListAsync();
        }

        public async Task<IEnumerable<Worker>> GetWorkersByIdAsync(int Id)
        {
            var id = new SqlParameter("@Id", Id);
            return await context.Workers
           .FromSqlRaw("SELECT * FROM Workers WHERE Id = @id", id)
           .ToListAsync();
        }

        public async Task<int> UpdateAsync(int id, CreateWorkerDTO workerDTO)
        {
            var commandText = "UPDATE Departaments SET MonthSalary = @MonthSalary, AwardSalary = @AwardSalary, PositionId = @PositionId, MonthSalary = @MonthSalary, AwardSalary=@AwardSalary" +
                "WHERE Id = @id";
            var FirstName = new SqlParameter("@MonthSalary", workerDTO.FirstName);
            var LastName = new SqlParameter("@AwardSalary", workerDTO.LastName);
            var Phone = new SqlParameter("@PositionId", workerDTO.Phone);
            var DepartamentId = new SqlParameter("@MonthSalary", workerDTO.DepartamentId);

            context.SaveChanges();
            return await context.Database.ExecuteSqlRawAsync(commandText, FirstName, LastName, Phone, DepartamentId);
        }

        public async Task<IEnumerable<Worker>> AddPositionToWorker(int id, AddPositionToWorkerDTO positionDTO)
        {
            var worker = await GetWorkersByIdAsync(id);
            if (worker == null)
            {
                return null;
            }
            var position = new Position
            {
                Name = positionDTO.Name,
                Index = positionDTO.Index,
                WorkerId = positionDTO.WorkerId


            };



            await context.Positions.AddAsync(position);
            await context.SaveChangesAsync();
            return await GetWorkersByIdAsync(id);
        }

        public Task<Worker> GetWorkerByNameAsync(string workerName)
        {
            throw new NotImplementedException();
        }
    }
}
