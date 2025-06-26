using Itau_invest.Models;
using Itau_invest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau_invest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperacaoController : ControllerBase
    {
        private readonly OperacaoService _operacaoService;

        public OperacaoController(OperacaoService operacaoService)
        {
            _operacaoService = operacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operacao>>> GetAll()
        {
            var operacoes = await _operacaoService.GetAllAsync();
            return Ok(operacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Operacao>> GetById(int id)
        {
            var operacao = await _operacaoService.GetByIdAsync(id);
            if (operacao == null)
                return NotFound();

            return Ok(operacao);
        }

        [HttpPost]
        public async Task<ActionResult<Operacao>> Create(Operacao operacao)
        {
            var novaOperacao = await _operacaoService.CreateAsync(operacao);
            return CreatedAtAction(nameof(GetById), new { id = novaOperacao.IdOperacao }, novaOperacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Operacao operacao)
        {
            var atualizado = await _operacaoService.UpdateAsync(id, operacao);
            if (!atualizado)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _operacaoService.DeleteAsync(id);
            if (!deletado)
                return NotFound();

            return NoContent();
        }
    }
}
