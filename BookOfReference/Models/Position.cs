using System.Text.Json.Serialization;

namespace BookOfReference.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Index { get; set; }  
        public List<Salary>? Salaries { get; set; }
        public Worker? Workers { get; set; }
        public int WorkerId { get; set; }
    }
}
