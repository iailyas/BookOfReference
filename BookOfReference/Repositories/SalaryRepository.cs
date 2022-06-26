using BookOfReference.DTO;
using BookOfReference.Models;
using BookOfReference.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookOfReference.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly ApplicationDBContext context;

        public SalaryRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Salary>> AddPositionToSalary(int id,AddPositionToSalaryDTO positionDTO)
        {
            var salary = await GetSalaryByIdAsync(id);
            if (salary == null)
            {
                return null;
            }
            var position = new Position
            {
                Name = positionDTO.Name,
                Index = positionDTO.Index
               


            };



            await context.Positions.AddAsync(position);
            await context.SaveChangesAsync();
            return await GetSalaryByIdAsync(id);

        }

        public async Task CreateAsync(CreateSalaryDTO salaryDTO)
        {
            context.AddAsync(salaryDTO);
            //var commandText = "INSERT INTO Departaments (MonthSalary,AwardSalary,PositionId)" +
            //    " VALUES (@MonthSalary,@AwardSalary,@PositionId)";
            //var MonthSalary = new SqlParameter("@MonthSalary", salaryDTO.MonthSalary);
            //var AwardSalary = new SqlParameter("@AwardSalary", salaryDTO.AwardSalary);
            //var PositionId = new SqlParameter("@PositionId", salaryDTO.PositionId);
            context.SaveChanges();
            //return await context.Database.ExecuteSqlRawAsync(commandText, MonthSalary, AwardSalary, PositionId);
        }

        public async Task<IEnumerable<Salary>> DeleteAsync(int salaryId)
        {
            var id = new SqlParameter("@id", salaryId);
            context.SaveChanges();
            return await context.Salaries
            .FromSqlRaw("DELETE FROM Salaries WHERE Id = @id", id).ToListAsync();
        }

        public async Task<IEnumerable<Salary>> GetAllSalaryAsync()
        {
            return await context.Salaries
          .FromSqlRaw("SELECT * FROM Salaries")
          
          .ToListAsync();
        }

        public async Task<IEnumerable<Salary>> GetSalaryByIdAsync(int salaryId)
        {
            var id = new SqlParameter("@Id", salaryId);
            return await context.Salaries
           .FromSqlRaw("SELECT * FROM Salaries WHERE Id = @id", id)
           .ToListAsync();
        }

        public async Task<Salary> GetSalaryByNameAsync(string salaryName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(int id, CreateSalaryDTO salaryDTO)
        {
            var commandText = "UPDATE Departaments SET MonthSalary = @MonthSalary, AwardSalary = @AwardSalary, PositionId = @PositionId"+
                "WHERE Id = @id";
            var MonthSalary = new SqlParameter("@MonthSalary", salaryDTO.MonthSalary);
            var AwardSalary = new SqlParameter("@AwardSalary", salaryDTO.AwardSalary);
            var PositionId = new SqlParameter("@PositionId", salaryDTO.PositionId);
            context.SaveChanges();
            return await context.Database.ExecuteSqlRawAsync(commandText, MonthSalary, AwardSalary, PositionId);
        }
    }
}
