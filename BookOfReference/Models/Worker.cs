namespace BookOfReference.Models
{
    public class Worker
    {
        public string Id { get; set; } 
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone { get; set; }
        public int Departament_Id { get; set; }
        public Departament Departament { get; set; }
        public int Position_Id { get; set; }
        public IList<Position> Positions { get; set; }

    }
}
