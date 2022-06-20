using System.Text.Json.Serialization;

namespace BookOfReference.Models
{
    public partial class Salary
    {
        public int Id { get; set; }
        public float MonthSalary { get; set; }
        public float AwardSalary { get; set; }
        [JsonIgnore]
        public virtual Position Position { get; set; }
        public int PositionId { get; set; }
    }
}
