using System.Text.Json.Serialization;

namespace BookOfReference.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public List<Position> Positions { get; set; }
        [JsonIgnore]
        public Departament? Departament { get; set; }
        public int? DepartamentId { get; set; }

    }
}
