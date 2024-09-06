using APICaching.Interface;
using APICaching.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace APICaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoTypeService _todoTypeService;
        private readonly IMemoryCache _memoryCache;

        public TodosController(
            ITodoTypeService todoTypeService,
            IMemoryCache memoryCache
            )
        {
            _todoTypeService = todoTypeService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            if (_memoryCache.TryGetValue("todosKey", out IEnumerable<Todo>? todos) && todos != null)
            {
                return Ok(new { message = "Using the todo cache", result = todos });
            }

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

            var result = await _todoTypeService.All();

            _memoryCache.Set("todosKey", result, cacheOptions);

            return Ok(new { message = "Using the api call", result });
        }
    }
}
