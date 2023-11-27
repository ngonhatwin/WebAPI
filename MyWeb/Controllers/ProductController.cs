using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWeb.Data;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbContextProduct context_;

        public ProductController(DbContextProduct context)
        {
            context_ = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list_Product = context_.Products.ToList();
            return Ok(list_Product);
        }

        //
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var product = context_.Products.SingleOrDefault(Pr => Pr.ID == Guid.Parse(id));
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost]
        public IActionResult Create(Models.Product myproduct) 
        {
            try
            {
                var new_product = new Data.Product
                {
                    Name = myproduct.Name,
                    Price = myproduct.Price,
                    Describe = myproduct.Describe,
                    Discount = myproduct.Discount,
                };
                context_.Add(new_product);
                context_.SaveChanges();
                return Ok(new_product);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, Models.Product product)
        {
            var putPr = context_.Products.SingleOrDefault(pu => pu.ID == id);
            if (putPr == null)
            {
                return NotFound();
            }
            putPr.Name = product.Name;
            putPr.Price = product.Price;    
            putPr.Describe = product.Describe;
            putPr.Discount = product.Discount;
            context_.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                //LINQ
                var product = context_.Products.SingleOrDefault(Pr => Pr.ID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                context_.Remove(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
