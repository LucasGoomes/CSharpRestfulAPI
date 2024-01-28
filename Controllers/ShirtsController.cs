using CSharpRestfulAPI.Filters.ActionFilters;
using CSharpRestfulAPI.Filters.ExceptionFilters;
using CSharpRestfulAPI.Models;
using CSharpRestfulAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace CSharpRestfulAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidadeShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {

            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilterAttribute]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId }, shirt);
        }
        [HttpPut("{id}")]
        [Shirt_ValidadeShirtIdFilter]
        [Shirt_ValidadeUpdateShirtFilterAttribute]
        [Shirt_HandleUpdateExceptionsFilterAttribute]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            ShirtRepository.UpdateShirt(shirt);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidadeShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);
            return Ok(shirt);
        }

    }
}
