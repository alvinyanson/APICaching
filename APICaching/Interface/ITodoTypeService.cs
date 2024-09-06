using APICaching.Models;

namespace APICaching.Interface
{
    public interface ITodoTypeService
    {
        Task<IEnumerable<Todo>> All();
    }
}
