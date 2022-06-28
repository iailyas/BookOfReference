using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string DepartamentName { get; set; }
        public string DepartamentPhone { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int WorkersCount { get; set; }
        public List<Worker>? Workers { get; set; }
        [JsonIgnore]
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
