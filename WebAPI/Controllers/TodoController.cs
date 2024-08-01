using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.ViewModels;

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

        [HttpGet]
        public async Task<ActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var models = await _repository.GetAsync(cancellationToken);
            return Ok(models.Select(s => new
            {
                s.Id,
                s.Descricao,
                s.DataConclusao,
                s.IsConcluido
            }).ToList());
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult> GetAsync(string id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetAsync(id, cancellationToken);
            return Ok(new
            {
                model.Id,
                model.Descricao,
                model.DataConclusao,
                model.IsConcluido
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(ViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = new Todo(descricao: viewModel.Descricao);
            await _repository.InsertAsync(model, cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync(ViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = await _repository.GetAsync(viewModel.Id, cancellationToken);

            model.Update(descricao: viewModel.Descricao);

            await _repository.UpdateAsync(model, cancellationToken);
            return Ok();
        }

        [HttpPut, Route("edit-concluido")]
        public async Task<ActionResult> EditAsync(UpdateLoteViewModel viewModel, CancellationToken cancellationToken)
        {
            var ids = viewModel.Itens.Select(s => s.Id).ToList();
            var models = await _repository.GetAsync(ids, cancellationToken);

            viewModel.Itens.ForEach(item =>
            {
                var model = models.Single(w => w.Id == item.Id);
                model.SetIsConcluido(item.IsConcluido);
            });

            await _repository.UpdateAsync(models, cancellationToken);
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }
    }
}
