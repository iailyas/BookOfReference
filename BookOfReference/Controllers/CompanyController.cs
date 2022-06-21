using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookOfReference;
using BookOfReference.Models;
using BookOfReference.Interfaces;
using BookOfReference.DTO;

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
        public async Task<IEnumerable<Company>> GetCompanyes()
        {
            return await companyService.GetAllCompaniesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Company>> GetCompany(int id)
        {

            return await companyService.GetCompanyByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<int> PutCompany(int id, CreateCompanyDTO companyDTO)
        {
            return await companyService.UpdateAsync(id,companyDTO);
        }

        [HttpPost]
        public async Task PostCompany(CreateCompanyDTO companyDTO)
        {  
            
            await companyService.CreateAsync(companyDTO);            
        }

        [HttpDelete("{id}")]
        public async Task DeleteCompany(int id)
        {
           companyService.DeleteAsync(id);

            
        }

        private bool CompanyExists(int id)
        {
            return true;
           // return (_context.Company?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
