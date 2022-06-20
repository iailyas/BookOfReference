using System.Text.Json.Serialization;

namespace BookOfReference.Models
{
    public partial class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Index { get; set; }
        public int SalaryId { get; set; }        
        public virtual List<Salary> Salaries { get; set; }
        [JsonIgnore]
        public virtual Worker? Worker { get; set; }
        public string? WorkerId { get; set; }
    }
}
