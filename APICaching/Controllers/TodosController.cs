using APICaching.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace APICaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OutputCache]
    public class TodosController : ControllerBase
    {
        private readonly ITodoTypeService _todoTypeService;

        public TodosController(ITodoTypeService todoTypeService)
        {
            _todoTypeService = todoTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _todoTypeService.All();

            return Ok(new { message = "Todos retrieved", result });
        }

        [HttpGet("{id:int}")]
        [OutputCache(PolicyName = "Expire20")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _todoTypeService.GetOne(id);

            return Ok(new { message = "Todo retrieved", result });
        }

        // Vary by query string of culture
        //[HttpGet("{id:int}")]
        //[OutputCache(PolicyName = "Query")]
        //public async Task<IActionResult> GetOne(int id)
        //{
        //    var result = await _todoTypeService.GetOne(id);

        //    return Ok(new { message = "Todo retrieved", result });
        //}
    }
}
