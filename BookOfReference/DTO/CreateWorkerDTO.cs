using BookOfReference.Models;

namespace BookOfReference.DTO
{
    public class CreateWorkerDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int PositionId { get; set; }
        public virtual Departament Departament { get; set; }
        public int DepartamentId { get; set; }
    }
}
