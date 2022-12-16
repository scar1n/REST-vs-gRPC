using ClientApp.Services;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerServiceController : ControllerBase
    {
        private IAnswersService AnswersService { get; set; }
        public AnswerServiceController(IAnswersService answersService)
        {
            AnswersService = answersService;
        }

        [HttpGet]
        public async Task<List<string>> Get(bool isGrpc)
        {
            if (isGrpc)
            {
                var answer = AnswersService.GrpcGet().Result;
                Task<List<string>> task = new Task<List<string>>(() => { return answer.StringsList.Strings.ToList<string>(); });
                task.Start();
                return await task;
            }
            else 
            {
                return await AnswersService.Get();
            }
        }
    }
}
