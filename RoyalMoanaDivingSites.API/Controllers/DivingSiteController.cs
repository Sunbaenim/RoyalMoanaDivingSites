using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalMoanaDivingSites.API.DTO;
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
    }
}
