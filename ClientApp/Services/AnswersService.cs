using Grpc.Net.Client;
using Newtonsoft.Json;
using System;
using System.Threading.Channels;

namespace ClientApp.Services
{
    public class AnswersService : IAnswersService
    {
        public async Task<Response> GrpcGet()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7111");
            var client = new GrpcSomethingService.GrpcSomethingServiceClient(channel);
            return await client.GetSomethingAsync(new EmptyParams { });
        }
        public async Task<List<string>> Get()
        {
            using (var client = new HttpClient())
            {
                string resultJson = await client.GetStringAsync("https://localhost:7111/SomethingService");
                List<string> strings = JsonConvert.DeserializeObject<List<string>>(resultJson);
                return strings;
            }
        }

    }
}
