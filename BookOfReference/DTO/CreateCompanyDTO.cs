namespace BookOfReference.DTO
{
    public class CreateCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Adress { get; set; } = null!;

    }
}
