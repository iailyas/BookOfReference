using BookOfReference.DTO;
using BookOfReference.Models;
using BookOfReference.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookOfReference.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDBContext context;

        public PositionRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(CreatePositionDTO positionDTO)
        {
            var commandText = "INSERT INTO Positions (Name,Index,SalaryId,WorkerId)" +
                " VALUES (@Name,@Index,@SalaryId,@WorkerId)";
            var Name = new SqlParameter("@DepartamentName", positionDTO.Name);
            var Index = new SqlParameter("@DepartamentPhone", positionDTO.Index);
            var SalaryId = new SqlParameter("@City", positionDTO.SalaryId);
            var WorkerId = new SqlParameter("@Region", positionDTO.WorkerId);
            context.SaveChanges();
            return await context.Database.ExecuteSqlRawAsync(commandText, Name, Index, SalaryId, WorkerId);
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
           .ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetPositionsByIdAsync(int positionId)
        {
            var id = new SqlParameter("@Id", positionId);
            return await context.Positions
           .FromSqlRaw("SELECT * FROM Positions WHERE Id = @id", id)
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
            var SalaryId = new SqlParameter("@SalaryId", positionDTO.SalaryId);
            var WorkerId = new SqlParameter("@WorkerId", positionDTO.WorkerId);
            context.SaveChanges();
            return await context.Database.ExecuteSqlRawAsync(commandText, Name, Index, SalaryId, WorkerId);
        }
    }
}
