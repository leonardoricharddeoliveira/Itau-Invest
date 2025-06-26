using Itau_invest.Models;
using Itau_invest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Itau_invest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly AtivoService _ativoService;

        public AtivoController(AtivoService ativoService)
        {
            _ativoService = ativoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ativo>>> GetAll()
        {
            var ativo = await _ativoService.GetAllAsync();
            return Ok(ativo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ativo>> GetById(int id)
        {
            var ativo = await _ativoService.GetByIdAsync(id);
            if (ativo == null) 
                return NotFound();
            return Ok(ativo);
        }

        [HttpPost]
        public async Task<ActionResult<Ativo>> Create(Ativo ativo)
        {
            var novoAtivo = await _ativoService.CreateAsync(ativo);
            return CreatedAtAction(nameof(GetById), new { id = novoAtivo.IdAtivo }, novoAtivo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ativo ativo)
        {
            var atualizado = await _ativoService.UpdateAsync(id, ativo);
            if (!atualizado)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _ativoService.DeleteAsync(id);
            if (!deletado)
                return NotFound();

            return NoContent();
        }

    }
}
