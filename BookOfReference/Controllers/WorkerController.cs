using BookOfReference.DTO;
using BookOfReference.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookOfReference.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {

        private readonly IWorkerService workerService;

        public WorkerController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }

        [HttpGet]
        public async Task<IEnumerable<Worker>> GetWorkers()
        {
            return await workerService.GetAllWorkersAsync();
        }

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
        [HttpPost("AddPosition")]
        public async Task AddPositionToWorker(int id, AddPositionToWorkerDTO positionDTO)
        {

            await workerService.AddPositionToWorker(id,positionDTO);
        }

        [HttpPut("{id}")]
        public async Task<int> PutWorker(int id, CreateWorkerDTO workerDTO)
        {
            return await workerService.UpdateAsync(id, workerDTO);
        }

        [HttpDelete("{id}")]
        public async Task DeleteWorker(int id)
        {
            await workerService.DeleteAsync(id);

        }
    }
}
