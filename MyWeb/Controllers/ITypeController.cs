using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWeb.Services;
using NuGet.Protocol;

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepository repository_;

        public TypeController(ITypeRepository repository)
        {
            repository_ = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = repository_.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
               
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = repository_.GetById(id);
                if (data == null)
                {
                    return NotFound($"Type with ID {id} not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, InterfaceModels.Types type)
        {
            if (id != type.Id)
            {
                return BadRequest();
            }
            try
            {
                repository_.Update(type);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                repository_.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
             
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Models.Type type)
        {
            try
            {
                var addedType = repository_.Add(type);
                return Ok(addedType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
