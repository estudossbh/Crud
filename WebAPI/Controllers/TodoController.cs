using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("todo")]
    public class TodoController : ControllerBase
    {
        public TodoController(TodoRepository repository)
        {
            _repository = repository;
        }

        private readonly TodoRepository _repository;

        [HttpGet, Route("{id}")]
        public async Task GetAsync(string id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetAsync(id, cancellationToken);
        }

        [HttpGet]
        public async Task GetAsync(CancellationToken cancellationToken)
        {

        }

        [HttpPost]
        public async Task CreateAsync(CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync("", cancellationToken);
        }

        [HttpPut]
        public async Task EditAsync(CancellationToken cancellationToken)
        {

        }

        [HttpDelete, Route("{id}")]
        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }
    }
}
