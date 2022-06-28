namespace Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public List<Departament>? Departaments { get; set; }
    }
}
