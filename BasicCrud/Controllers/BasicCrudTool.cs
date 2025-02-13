using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    [ApiController]
    public class BasicCrudTool : ControllerBase
    {
        /// <summary>
        /// Ping server
        /// </summary>
        /// <returns>200 OK</returns>
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
