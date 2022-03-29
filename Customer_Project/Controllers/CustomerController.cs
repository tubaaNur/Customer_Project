using Customer_Project.Properties.Models;
using Microsoft.AspNetCore.Mvc;
using Customer_Project.DbModel;
using Microsoft.EntityFrameworkCore;

namespace Customer_Project.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataBaseContext _db;
        private CustomerEntities customerToDelete;

        //public CustomerController(DataBaseContext db)
        //{
        //    _db = db;
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            var context = new DataBaseContext();
            var Customer1 = _db.CustomersEntities.ToList();
            return GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerEntities customer)
        {
            _db.CustomersEntities.Add(customer);
            _db.SaveChanges();
            return Ok(customer);
        }

        //[HttpPut]
        //public IActionResult Update(int id, CustomerEntities customer1)
        //{
        //    customer1.Id = id;
        //    _db.Entry(customer1).State = EntityState.Modified;
        //    _db.SaveChanges();
        //    return Update(customer1);

        //}

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var customerToDelete = _db.CustomersEntities.Find(id);
            if (customerToDelete == null)
            {
                return NotFound();
            }

            _db.CustomersEntities.Remove(customerToDelete);
            _db.SaveChanges();
            return NoContent();


        }
    }
}

