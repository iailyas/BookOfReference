namespace BookOfReference.Models
{
    public interface Salary
    {
        public int Id { get; set; }
        public float Salary { get; set; }
        public float Award_Salary { get; set; }
        public Position Position { get; set; }
    }
}
