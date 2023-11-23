using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWeb.Data;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly DbContextProduct context_;

        public TypesController(DbContextProduct context) 
        { 
            context_ = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var catelory_List = context_.Types.ToList();
            return Ok(catelory_List);
        }


        [HttpGet("{id}")]
        public IActionResult GetbyID(int id) 
        {
            var catelory = context_.Types.SingleOrDefault(ca => ca.TypeID == id);
            if (catelory == null)
            {
                return NotFound();
            }
            return Ok(catelory);
        }

        [HttpPost]
        public IActionResult CreateNew(TypeModel model)
        {
            try
            {
                var new_type = new Data.Type
                {
                    TypeName = model.Name,
                };
                context_.Add(new_type);
                context_.SaveChanges();
                return Ok(new_type);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]

        public IActionResult UpdateByID(int id, TypeModel model)
        {
            var catelory = context_.Types.SingleOrDefault(ca => ca.TypeID == id);
            if (catelory == null)
            {
                return NotFound();
            }
            catelory.TypeName = model.Name;
            context_.SaveChanges();
            return NoContent();
        }


    }
}
