namespace ClientApp.Services
{
    public interface IAnswersService
    {
        public Task<List<string>> Get();
        public Task<Response> GrpcGet();
    }
}
