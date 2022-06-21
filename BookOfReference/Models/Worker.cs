using System.Text.Json.Serialization;

namespace BookOfReference.Models
{
    public partial class Worker
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public virtual List<Position> Positions { get; set; }
        [JsonIgnore]
        public virtual Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        
    }
}
