using BookOfReference.DTO;
using BookOfReference.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookOfReference.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : Controller
    {
        private readonly ISalaryService salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            this.salaryService = salaryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Salary>> GetSalaries()
        {
            return await salaryService.GetAllSalaryAsync();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Salary>> GetSalaries(int id)
        {

            return await salaryService.GetSalaryByIdAsync(id);
        }
        //[HttpPost("AddPositionToSalary")]
        //public async Task AddPositionToSalary(int id,AddPositionToSalaryDTO salaryDTO)
        //{

        //    await salaryService.AddPositionToSalary(id,salaryDTO);
        //}
        
        //[HttpPost]
        //public async Task PostSalary(CreateSalaryDTO salaryDTO)
        //{

        //    await salaryService.CreateAsync(salaryDTO);
        //}

        [HttpPut("{id}")]
        public async Task<int> PutSalary(int id, CreateSalaryDTO salaryDTO)
        {
            return await salaryService.UpdateAsync(id, salaryDTO);
        }

        [HttpDelete("{id}")]
        public async Task DeleteSalary(int id)
        {
            await salaryService.DeleteAsync(id);

        }
    }
}
