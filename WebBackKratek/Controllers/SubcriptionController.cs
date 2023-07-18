using KratekData.Data.ConnectDB;
using Microsoft.AspNetCore.Mvc;

namespace WebBackKratek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcriptionController : Controller
    {
        DataContext _dataContext;
        public SubcriptionController(DataContext data)
        {
            _dataContext = data;
        }

        [HttpGet]
        public async Task<IActionResult> GetTest()
        {
            var status = _dataContext.Database.CanConnect();

            return Ok("ServerRes");
        }
    }
}
