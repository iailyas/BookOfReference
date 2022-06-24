using BookOfReference.DTO;
using BookOfReference.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookOfReference.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : Controller
    {
        private readonly IPositionService positionService;

        public PositionController(IPositionService positionService)
        {
            this.positionService = positionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await positionService.GetAllPositionsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Position>> GetPosition(int id)
        {

            return await positionService.GetPositionsByIdAsync(id);
        }

        [HttpPost]
        public async Task PostPosition(CreatePositionDTO positionDTO)
        {

            await positionService.CreateAsync(positionDTO);
        }

        [HttpPut("{id}")]
        public async Task<int> PutPosition(int id, CreatePositionDTO positionDTO)
        {
            return await positionService.UpdateAsync(id, positionDTO);
        }

        [HttpDelete("{id}")]
        public async Task DeletePosition(int id)
        {
            await positionService.DeleteAsync(id);

        }
    }
}
