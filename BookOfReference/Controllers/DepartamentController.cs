using BookOfReference.DTO;
using BookOfReference.Models;
using Microsoft.AspNetCore.Http;
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
        public async Task<IEnumerable<Departament>> GetCompanies()
        {
            return await departamentService.GetAllDepartamentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Departament>> GetCompany(int id)
        {

            return await departamentService.GetDepartamentsByIdAsync(id);
        }

        [HttpPost]
        public async Task PostCompany(CreateDepartamentDTO departamentDTO)
        {

            await departamentService.CreateAsync(departamentDTO);
        }

        [HttpPut("{id}")]
        public async Task<int> PutCompany(int id, CreateDepartamentDTO departamentDTO)
        {
            return await departamentService.UpdateAsync(id, departamentDTO);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCompany(int id)
        {
            await departamentService.DeleteAsync(id);

        }
    }
}
