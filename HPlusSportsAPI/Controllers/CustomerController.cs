using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HPlusSportsAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerRepository CustomerItems { get; set; }

        public CustomerController(ICustomerRepository customerItems)
        {
            CustomerItems = customerItems;
        }

        // GET: api/<controller>
        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IEnumerable<Customer> GetAll() => CustomerItems.GetAll();

        // GET api/<controller>/5
        [HttpGet("{id}", Name="GetCustomer")]
        public IActionResult Get(int id)
        {
            var Item = CustomerItems.Find(id);
            if (Item == null)
            {
                return NotFound();
            }
            return new ObjectResult(Item);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Customer value)
        {
            if (value == null)
            {
                return BadRequest();

            }
            TryValidateModel(value);
            if (this.ModelState.IsValid)
            {
                CustomerItems.Add(value);
            }
            else
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetCustomer", new { controller = "Customer", id = value.CustomerId }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer value)
        {
            var Customer = CustomerItems.Find(id);
            CustomerItems.Update(value);
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CustomerItems.Remove(id);
        }
    }
}
