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
      
        //public CustomerController(DataBaseContext db)
        //{
        //    _db = db;
        //}



        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var context = new DataBaseContext();
            var Customer1 = context.customer.ToList();
            return Ok(Customer1);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {

            var context = new DataBaseContext();

            var customer = context.customer.Where(a => a.Id == id).ToList();
            var customer1 = context.customer.FirstOrDefault(x => x.Id == id);
            return Ok(customer);

        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CustomerEntities customer)
        {
            var context = new DataBaseContext();
            context.customer.Add(customer);
            context.SaveChanges();
            return Ok(customer);
        }

        [HttpPut]
        [Route("Update")]

        public IActionResult Update(CustomerEntities customer1)
        {

            var context = new DataBaseContext();
            context.Entry(customer1).State = EntityState.Modified;
            context.SaveChanges();
            return Ok("Değiştirildi");
        }

        [HttpDelete]
        [Route("Delete")]

        public IActionResult Delete(int id)
        {
            var context = new DataBaseContext();

            var customerToDelete = context.customer.Find(id);
            if (customerToDelete == null)
            {
                return NotFound("Bulunamadı");
            }
            context.customer.Remove(customerToDelete);
            context.SaveChanges();
            return NoContent();
        }
    }
}

