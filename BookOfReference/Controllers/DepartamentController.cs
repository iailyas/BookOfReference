using BookOfReference.DTO;
using BookOfReference.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookOfReference.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : Controller
    {
        private readonly IDepartamentService departamentService;

        public DepartamentController(IDepartamentService departamentService)
        {
            this.departamentService = departamentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Departament>> GetDepartaments()
        {
            return await departamentService.GetAllDepartamentsAsync();
        }

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
        [HttpPost("AddWorker")]
        public async Task AddWorkerToDepartament(int id,CreateWorkerDTO workerDTO)
        {

            await departamentService.AddWorkerToDepartament(id,workerDTO);
        }

        [HttpPut("{id}")]
        public async Task<int> PutDepartament(int id, CreateDepartamentDTO departamentDTO)
        {
            return await departamentService.UpdateAsync(id, departamentDTO);
        }

        [HttpDelete("{id}")]
        public async Task DeleteDepartament(int id)
        {
            await departamentService.DeleteAsync(id);

        }
    }
}
