using APICaching.Data;
using APICaching.Interface;
using APICaching.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;
        private readonly ICacheService _cacheService;
        private readonly AppDbContext _appDbContext;

        public TodosController(
            ILogger<TodosController> logger,
            ICacheService cacheService,
            AppDbContext appDbContext)
        {
            _logger = logger;
            _cacheService = cacheService;
            _appDbContext = appDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // check cache data
            var cacheData = _cacheService.Get<List<Todo>>("todos");

            if (cacheData != null && cacheData.Count > 0)
            {
                return Ok(cacheData);
            }

            cacheData = await _appDbContext.Todos.ToListAsync();
            
            _cacheService.Set<List<Todo>>("todos", cacheData, DateTimeOffset.Now.AddSeconds(30));

            return Ok(cacheData);
        }
    }
}
