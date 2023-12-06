namespace lab6.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fio { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public int Age { get; set; }
    }
}
