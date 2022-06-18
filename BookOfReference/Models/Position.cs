namespace BookOfReference.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Index { get; set; }
        public int Salary_Id { get; set; }
        public Worker Worker { get; set; }
        public IList<Salary> Salaries { get; set; }
    }
}
