using BaseCureAPI.DB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseCureAPI.Endpoints
{
    [Route("auth")]
    [ApiController]
    public class LoginEndpoints : ControllerBase
    {
        private readonly BaseCureContext _context;

        public LoginEndpoints(BaseCureContext context)
        {
            _context = context;
        }

        // POST auth/login
        [HttpPost("login")]
        public void Post([FromBody] string value)
        {

        }

    }
}
