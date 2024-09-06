using APICaching.Interface;
using APICaching.Models;

namespace APICaching.Services
{
    public class TodoTypeService : ITodoTypeService
    {
        private readonly HttpClient _httpClient;

        public TodoTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<IEnumerable<Todo>> All()
        {

            var httpResponse = await _httpClient.GetAsync("todos");

            var todos = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<Todo>>();

            return todos ?? Enumerable.Empty<Todo>();
        }
    }
}
