namespace CitasSalud.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string? UserName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserPhone { get; set; }
        public string? UserEmail { get; set; }
        public DateTime UserDateBirth { get; set; }
    }
}
