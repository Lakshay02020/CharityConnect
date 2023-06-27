using Microsoft.AspNetCore.Mvc;
using charity.NGOService;
using charity.Models;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoExample.Controllers
{
    [ApiController]
    [Route("api/ngo")]
    [EnableCors("AllowAllOrigins")]
    public class NGOController : ControllerBase
    {
        private readonly NGOService _ngoService;

        public NGOController(NGOService ngoService)
        {
            _ngoService = ngoService;
        }

        [HttpGet]
        public async Task<List<NGO>> Get()
        {
            return await _ngoService.GetNGOsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NGO ngo)
        {
            await _ngoService.AddNGOAsync(ngo);
            return CreatedAtAction(nameof(Get), new { id = ngo.Id }, ngo);
        }
    }
}
