using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Identity.Data;
using WebAPI_Identity.Models;

namespace WebAPI_Identity.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            this._context = context;
        }
            
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _context.Products;

            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var prod = _context.Products.Find(id);
            if (prod is not null)
                return new JsonResult(prod);
            else
                return NotFound();
        }

        // POST: api/Products
        [HttpPost]
        public Product Post([FromBody] Product value)
        {
            _context.Add(value);
            _context.SaveChanges();

            return value;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product value)
        {
            var prod = _context.Products.AsNoTracking().Where(p => p.Id == id);

            if (prod is not null)
            {
                _context.Update(value);
                _context.SaveChanges();
                return new JsonResult(prod);    // I return the old product values (before the update)
            } else
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var prod = _context.Products.Find(id);
            if(prod is not null) { 
                _context.Remove(prod);
                _context.SaveChanges();
                return new JsonResult(prod);    // I return the deleted product
            } else
            {
                return NotFound();
            }
        }
    }
}
