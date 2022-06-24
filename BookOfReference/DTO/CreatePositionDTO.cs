using BookOfReference.Models;

namespace BookOfReference.DTO
{
    public class CreatePositionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Index { get; set; }
        public int SalaryId { get; set; }
        public virtual Worker? Worker { get; set; }
        public string? WorkerId { get; set; }
    }
}
