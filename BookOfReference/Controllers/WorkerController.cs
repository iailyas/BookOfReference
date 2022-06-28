
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
    public class WorkerController : Controller
    {

        private readonly IWorkerService workerService;

        public WorkerController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Worker>> GetWorkers()
        {
            return await workerService.GetAllWorkersAsync();
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IEnumerable<Worker>> GetWorkers(int id)
        {

            return await workerService.GetWorkerByIdAsync(id);
        }

        //[HttpPost]
        //public async Task PostWorker(CreateWorkerDTO workerDTO)
        //{

        //    await workerService.CreateAsync(workerDTO);
        //}
        [Authorize]
        [HttpPost("AddPosition")]
        public async Task AddPositionToWorker(int id, AddPositionToWorkerDTO positionDTO)
        {

            await workerService.AddPositionToWorker(id, positionDTO);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<int> PutWorker(int id, CreateWorkerDTO workerDTO)
        {
            return await workerService.UpdateAsync(id, workerDTO);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteWorker(int id)
        {
            await workerService.DeleteAsync(id);

        }
    }
}
