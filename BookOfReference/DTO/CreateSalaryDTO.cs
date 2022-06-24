using BookOfReference.Models;

namespace BookOfReference.DTO
{
    public class CreateSalaryDTO
    {
        public int Id { get; set; }
        public float MonthSalary { get; set; }
        public float AwardSalary { get; set; }
        public virtual Position Position { get; set; }
        public int PositionId { get; set; }
    }
}
