using System.Text.Json.Serialization;

namespace BookOfReference.Models
{
    public partial class Departament
    {
        public int Id { get; set; }
        public string DepartamentName { get; set; }
        public string DepartamentPhone { get; set; }
        public string City { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int WorkersCount { get; set; }
        [JsonIgnore]
        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
