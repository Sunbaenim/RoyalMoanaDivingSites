using Microsoft.AspNetCore.Mvc;
using RoyalMoanaDivingSites.API.DTO.DivingSite;
using RoyalMoanaDivingSites.API.Services;

namespace RoyalMoanaDivingSites.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivingSiteController : ControllerBase
    {
        private readonly DivingSiteService _ds;

        public DivingSiteController(DivingSiteService ds)
        {
            _ds = ds;
        }

        [HttpGet]
        public IActionResult GetDivingSites([FromQuery]DivingSiteFilterDTO filter)
        {
            return Ok(_ds.GetAllDivingSites(filter));
        }

        [HttpGet("{divingSiteId}")]
        public IActionResult GetDivingSiteById(int divingSiteId)
        {
            try
            {
                return Ok(_ds.GetDivingSiteById(divingSiteId));
            }
            catch (KeyNotFoundException)
            {
                return NotFound(divingSiteId);
            }
        }

        [HttpPost]
        public IActionResult CreateDivingSite(DivingSiteAddDTO form)
        {
            try
            {
                return Ok(_ds.CreateDivingSite(form));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{divingSiteId}")]
        public IActionResult DeleteDivingSite(int divingSiteId)
        {
            try
            {
                return Ok(_ds.DeleteDivingSite(divingSiteId));
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
