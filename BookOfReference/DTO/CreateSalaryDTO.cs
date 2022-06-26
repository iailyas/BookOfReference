using BookOfReference.Models;

namespace BookOfReference.DTO
{
    public class CreateSalaryDTO
    {
        public float MonthSalary { get; set; }
        public float AwardSalary { get; set; }
        public int? PositionId { get; set; }
    }
}
