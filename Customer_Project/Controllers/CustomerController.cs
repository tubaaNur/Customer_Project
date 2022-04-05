using Customer_Project.DbModel;
using Customer_Project.Properties.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Customer_Project.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataBaseContext _db;

        //private readonly IConfiguration _configuration;
        public CustomerController(DataBaseContext db)
        {

            _db = db;
        }
        
        //public CustomerController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

      
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Customer1 = _db.customer.ToList();
            return Ok(Customer1);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var customer = _db.customer.Where(a => a.Id == id).ToList();
            var customer1 = _db.customer.FirstOrDefault(x => x.Id == id);
            return Ok(customer);

        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody]CustomerEntities customer)
        {

            _db.customer.Add(customer);
            _db.SaveChanges();
            return Ok(customer);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]CustomerEntities customer1)
        {
            _db.customer.Update(customer1);
            _db.SaveChanges();
            return Ok(customer1);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var customerToDelete = _db.customer.Find(id);
            if (customerToDelete == null)
            {
                return NotFound("Bulunamadı");
            }
            _db.customer.Remove(customerToDelete);
            _db.SaveChanges();
            return NoContent();
        }
    }
}

