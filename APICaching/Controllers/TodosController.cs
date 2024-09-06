using APICaching.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APICaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var result =  await _todoTypeService.All();

            return Ok(result);
        }
    }
}
