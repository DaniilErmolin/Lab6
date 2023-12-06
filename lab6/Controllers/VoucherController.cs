using lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : Controller
    {
        TouristAgencyContext db;
        public VoucherController(TouristAgencyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Voucher> Get()
        {
            var result = db.Vouchers
                .Include(e => e.Employess)
                .Include(e => e.AdditionalService)
                .ToList();
            return result;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Voucher voucher = db.Vouchers
                .Include(e => e.Employess)
                .Include(e => e.AdditionalService)
                .FirstOrDefault(x => x.Id == id);
            
            if (voucher == null)
                return NotFound();
            return new ObjectResult(voucher);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] Voucher voucher)
        {
            if (voucher == null)
            {
                return BadRequest();
            }

            db.Vouchers.Add(voucher);
            db.SaveChanges();
            return Ok(voucher);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody] Voucher voucher)
        {
            if (voucher == null)
            {
                return BadRequest();
            }
            if (!db.Vouchers.Any(x => x.Id == voucher.Id))
            {
                return NotFound();
            }

            db.Update(voucher);
            db.SaveChanges();
            return Ok(voucher);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Voucher voucher = db.Vouchers.FirstOrDefault(x => x.Id == id);
            if (voucher == null)
            {
                return NotFound();
            }
            db.Vouchers.Remove(voucher);
            db.SaveChanges();
            return Ok(voucher);
        }

        [HttpGet("emloyes")]
        [Produces("application/json")]
        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }

        [HttpGet("additionalService")]
        [Produces("application/json")]
        public IEnumerable<AdditionalService> GetAdditionalService()
        {
            return db.AdditionalServices.ToList();
        }
    }

}