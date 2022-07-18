using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetDivingSites()
        {
            return Ok(_ds.GetAllDivingSites());
        }
    }
}
