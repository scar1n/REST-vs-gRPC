using Microsoft.AspNetCore.Mvc;
using ServiceApp.Services;

namespace ServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SomethingServiceController : ControllerBase
    {
        private ISomethingService SomethingService { get; set; }
        public SomethingServiceController(ISomethingService somethingService)
        {
            SomethingService = somethingService;
        }

        [HttpGet(Name = "Get")]
        public List<string> Get()
        {
            return SomethingService.GetAll();
        }
    }
}