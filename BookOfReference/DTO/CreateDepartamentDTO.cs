namespace BookOfReference.DTO
{
    public class CreateDepartamentDTO
    {
        public string DepartamentName { get; set; }
        public string DepartamentPhone { get; set; }
        public string City { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int WorkersCount { get; set; }
        public int CompanyId { get; set; }
    }
}
