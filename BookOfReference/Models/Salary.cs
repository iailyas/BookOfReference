using System.Text.Json.Serialization;

namespace BookOfReference.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public float MonthSalary { get; set; }
        public float AwardSalary { get; set; }
        [JsonIgnore]
        public Position? Position { get; set; }
        public int? PositionId { get; set; }
    }
}
