
using Domain.DTO;
using Domain.Models;
using Domain.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookOfReference.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SalaryController : Controller
    {
        private readonly ISalaryService salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            this.salaryService = salaryService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Salary>> GetSalaries()
        {
            return await salaryService.GetAllSalaryAsync();
        }
        [Authorize]
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
        [Authorize]
        [HttpPut("{id}")]
        public async Task<int> PutSalary(int id, CreateSalaryDTO salaryDTO)
        {
            return await salaryService.UpdateAsync(id, salaryDTO);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteSalary(int id)
        {
            await salaryService.DeleteAsync(id);

        }
    }
}
