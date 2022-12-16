namespace ServiceApp.Services
{
    public class SomethingService : ISomethingService
    {
        private List<string> strings = new List<string> {"some236541", "some12321", "some65421", "some212321" };
        public List<string> GetAll()
        {
            Console.WriteLine("REST Запрос выполнен");
            return strings;
        }
    }
}
