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

namespace BookOfReference.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository repository;
        private readonly ApplicationDBContext context;
       

        public CompanyController(ICompanyRepository repository, ApplicationDBContext context)
        {
            this.repository = repository;
            this.context = context;
        }



        // GET: api/Company
        [HttpGet]
        public async Task<IEnumerable<Company>> GetCompany()
        {
         
            return await repository.GetAllCompaniesAsync();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompany(int id)
        {

            return BadRequest();
        }

        // PUT: api/Company/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
           
            return NoContent();
        }

        // POST: api/Company
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostCompany(Company company)
        {
          
            await repository.CreateAsync(company);
            

            
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
           
            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return true;
           // return (_context.Company?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
