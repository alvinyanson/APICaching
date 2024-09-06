using APICaching.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APICaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TodosController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ITodoTypeService _todoTypeService;

        public TodosController(
            ILogger<TodosController> logger,
            ITodoTypeService todoTypeService)
        {
            _logger = logger;
            _todoTypeService = todoTypeService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {
            var result = await _todoTypeService.All();

            _logger.LogInformation("Retrieved todos from api");

            return Ok(new { message = "Todos retrieved", time = DateTime.Now, result });
        }

        [HttpGet("{id:int}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "id" })]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _todoTypeService.GetOne(id);
            
            _logger.LogInformation("Retrieved todo from api");

            return Ok(new { message = "Todo retrieved", result });
        }

        [HttpGet("VaryByHeader/{id:int}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "User-Agent")]
        public async Task<IActionResult> GetOneVary(int id)
        {
            var result = await _todoTypeService.GetOne(id);

            _logger.LogInformation("Retrieved todo from api");

            return Ok(new { message = "Todo retrieved", result });
        }
    }
}
