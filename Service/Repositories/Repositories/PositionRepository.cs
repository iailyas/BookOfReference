
using Domain.DTO;
using Domain.Models;
using Domain.RepositryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Service.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDBContext context;

        public PositionRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Position>> AddSalaryToPosition(int id, CreateSalaryDTO salaryDTO)
        {
            var position = await GetPositionsByIdAsync(id);
            if (position == null)
            {
                return null;
            }
            var salary = new Salary
            {
                MonthSalary = salaryDTO.MonthSalary,
                AwardSalary = salaryDTO.AwardSalary,
                PositionId = salaryDTO.PositionId

            };



            await context.Salaries.AddAsync(salary);
            await context.SaveChangesAsync();
            return await GetPositionsByIdAsync(id);
        }

        //public async Task<IEnumerable<Position>> AddWorkerToPosition(int id, AddWorkerToPositionDTO workerDTO)
        //{
        //    var position = await GetPositionsByIdAsync(id);
        //    if (position == null)
        //    {
        //        return null;
        //    }
        //    var worker = new Worker
        //    {
        //        FirstName = workerDTO.FirstName,
        //        LastName = workerDTO.LastName,
        //        Phone = workerDTO.Phone
        //    };



        //    await context.Workers.AddAsync(worker);
        //    await context.SaveChangesAsync();
        //    return await GetPositionsByIdAsync(id);
        //}

        public async Task CreateAsync(CreatePositionDTO positionDTO)
        {
            await context.AddAsync(positionDTO);
            //var commandText = "INSERT INTO Positions (Name,Index,SalaryId,WorkerId)" +
            //    " VALUES (@Name,@Index,@SalaryId,@WorkerId)";
            //var Name = new SqlParameter("@DepartamentName", positionDTO.Name);
            //var Index = new SqlParameter("@DepartamentPhone", positionDTO.Index);

            context.SaveChanges();
            //return await context.Database.ExecuteSqlRawAsync(commandText, Name, Index);
        }

        public async Task<IEnumerable<Position>> DeleteAsync(int positionId)
        {
            var id = new SqlParameter("@id", positionId);
            context.SaveChanges();
            return await context.Positions
            .FromSqlRaw("DELETE FROM Positions WHERE Id = @id", id).ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await context.Positions
           .FromSqlRaw("SELECT * FROM Positions")
           .Include(c => c.Workers)
           .Include(c => c.Salaries)

           .ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetPositionsByIdAsync(int positionId)
        {
            var id = new SqlParameter("@Id", positionId);
            return await context.Positions
           .Include(c => c.Salaries)

           .Include(d => d.Workers)
           .ToListAsync();
        }

        public Task<Position> GetPositionsByNameAsync(string positionName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(int id, CreatePositionDTO positionDTO)
        {
            var commandText = "UPDATE Positions SET Name = @Name, Index = @Index, SalaryId = @SalaryId, WorkerId = @WorkerId" +
                "WHERE Id = @id";
            var Name = new SqlParameter("@Name", positionDTO.Name);
            var Index = new SqlParameter("@Index", positionDTO.Index);

            context.SaveChanges();
            return await context.Database.ExecuteSqlRawAsync(commandText, Name, Index);
        }
    }
}
