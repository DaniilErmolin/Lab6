namespace lab6.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int AdditionalServiceId { get; set; }
        public int EmployessId { get; set; }
        public bool Reservation { get; set; }
        public bool Payment { get; set; }

        public virtual AdditionalService? AdditionalService { get; set; } = null!;

        public virtual Employee? Employess { get; set; } = null!;
    }
}
