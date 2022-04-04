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
        private CustomerEntities customerToDelete;
       
        public CustomerController(DataBaseContext db)
        {

            _db = db;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var Customer1 = _db.customer.ToList();
            return Ok(Customer1);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var customer = _db.customer.Where(a => a.Id == id).ToList();
            var customer1 = _db.customer.FirstOrDefault(x => x.Id == id);
            return Ok(customer);

        }

        [HttpPost]
        [Route("Create")]
        public  IActionResult Create([FromBody] CustomerEntities customer)
        {
           
            _db.customer.Add(customer);
            _db.SaveChanges();
            return Ok(customer);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] CustomerEntities customer1)
        {
            _db.customer.Update(customer1);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
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

