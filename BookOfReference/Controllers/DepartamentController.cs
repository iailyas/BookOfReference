
using Domain.DTO;
using Domain.Models;
using Domain.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookOfReference.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : Controller
    {
        private readonly IDepartamentService departamentService;

        public DepartamentController(IDepartamentService departamentService)
        {
            this.departamentService = departamentService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Departament>> GetDepartaments()
        {
            return await departamentService.GetAllDepartamentsAsync();
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IEnumerable<Departament>> GetDepartament(int id)
        {

            return await departamentService.GetDepartamentsByIdAsync(id);
        }

        //[HttpPost]
        //public async Task PostDepartament(CreateDepartamentDTO departamentDTO)
        //{

        //    await departamentService.CreateAsync(departamentDTO);
        //}
        [Authorize]
        [HttpPost("AddWorker")]
        public async Task AddWorkerToDepartament(int id, CreateWorkerDTO workerDTO)
        {

            await departamentService.AddWorkerToDepartament(id, workerDTO);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<int> PutDepartament(int id, CreateDepartamentDTO departamentDTO)
        {
            return await departamentService.UpdateAsync(id, departamentDTO);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteDepartament(int id)
        {
            await departamentService.DeleteAsync(id);

        }
    }
}
