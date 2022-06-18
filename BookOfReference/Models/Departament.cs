namespace BookOfReference.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public int Company_Id { get; set; }
        public string Departament_Name { get; set; }
        public string Departament_Phone { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int Workers_Count { get; set; }
        public Company Company { get; set; }
        public IList<Worker> Workers { get; set; }
        

    }
}
