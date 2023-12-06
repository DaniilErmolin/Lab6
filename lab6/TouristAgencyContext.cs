using lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace lab6
{
    public class TouristAgencyContext : DbContext
    {
        public TouristAgencyContext()
        {
        }

        public TouristAgencyContext(DbContextOptions<TouristAgencyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Voucher> Vouchers { get; set; }
    }
}
