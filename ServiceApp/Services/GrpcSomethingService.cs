using Google.Protobuf.Collections;
using Grpc.Core;
using ServiceApp;

namespace ServiceApp.Services
{
    public class GrpcSomethingService : ServiceApp.GrpcSomethingService.GrpcSomethingServiceBase
    {
        private List<string> strings = new List<string> { "some236541", "some12321", "some65421", "some212321" };
        private readonly ILogger<GrpcSomethingService> _logger;
        public GrpcSomethingService(ILogger<GrpcSomethingService> logger)
        {
            _logger = logger;
        }

        public override Task<Response> GetSomething(EmptyParams request, ServerCallContext context)
        {
            var stringsList = new ListOfStrings();
            stringsList.Strings.Add(strings);

            Console.WriteLine("gRPC Запрос выполнен");

            return Task.FromResult(new Response
            {
                StringsList = stringsList
            }) ;
        }
    }
}
