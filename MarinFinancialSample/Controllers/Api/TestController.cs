using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarinFinancialSample.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        public TestController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("reset")]
        public IActionResult Reset()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
            return new JsonResult(new { message = "Success" });
        }

    }
}
