namespace BookOfReference.DTO
{
    public class CreateDepartamentDTO
    {
        public string DepartamentName { get; set; }
        public string DepartamentPhone { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int WorkersCount { get; set; }
        public int? CompanyId { get; set; }
    }
}
