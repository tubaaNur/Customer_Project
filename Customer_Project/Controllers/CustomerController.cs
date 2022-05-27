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

        public CustomerController(DataBaseContext db)
        {

            _db = db;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Customer1 = _db.customer.ToList();


            return Ok(Customer1);
        }

        [HttpGet("GetById")] // ıdye göre customer değeri döner. ıd yoksa hata döner
        public IActionResult GetById(int id)
        {
            var customer = _db.customer.FirstOrDefault(x => x.Id == id);
            return Ok(customer);
        }

        [HttpGet("GetByNation")]
        public IActionResult GetGirl(char nation)
        {
            var customer = _db.customer.Where(x => x.Nation == nation);
            return Ok(customer);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CustomerEntities customer)
        {

            _db.customer.Add(customer);
            _db.SaveChanges();
            return Ok(customer);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomerEntities customer1)
        {
            _db.customer.Update(customer1);
            _db.SaveChanges();
            return Ok(customer1);
        }

        [HttpDelete("Delete")]

        public virtual IActionResult Delete(int id)
        {
            var customerToDelete = _db.customer.Find(id);
            if (customerToDelete == null) // getbyıd de olabilir
            {
                return NotFound("Bulunamadı");
            }
            customerToDelete.Is_active = false;
            _db.customer.Update(customerToDelete);
            _db.SaveChanges();
            return NoContent();
        }

    }
}