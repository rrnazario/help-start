using CozinhaPedidos.Core.Interfaces.Services;
using CozinhaPedidos.Domain.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CozinhaPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        // Aqui definimos e utilizamos a interface de serviço.
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clienteService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //Retornar um ClienteViewModel
            var result = await _clienteService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(ClienteInputModel cliente)
        {                       
            return CreatedAtAction(nameof(Create), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ClienteInputModel cliente)
        {


            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
