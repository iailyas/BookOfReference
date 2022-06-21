using BookOfReference.DTO;
using BookOfReference.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookOfReference.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }


        [HttpGet]
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await companyService.GetAllCompaniesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Company>> GetCompany(int id)
        {

            return await companyService.GetCompanyByIdAsync(id);
        }

        [HttpPost]
        public async Task PostCompany(CreateCompanyDTO companyDTO)
        {

            await companyService.CreateAsync(companyDTO);
        }

        [HttpPut("{id}")]
        public async Task<int> PutCompany(int id, CreateCompanyDTO companyDTO)
        {
            return await companyService.UpdateAsync(id, companyDTO);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCompany(int id)
        {
            await companyService.DeleteAsync(id);

        }
    }
}
