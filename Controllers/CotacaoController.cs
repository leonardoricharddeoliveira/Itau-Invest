using Itau_invest.Models;
using Itau_invest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau_invest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CotacaoController : ControllerBase
    {
        private readonly CotacaoService _cotacaoService;

        public CotacaoController(CotacaoService cotacaoService)
        {
            _cotacaoService = cotacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotacao>>> GetAll()
        {
            var cotacoes = await _cotacaoService.GetAllAsync();
            return Ok(cotacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cotacao>> GetById(int id)
        {
            var cotacao = await _cotacaoService.GetByIdAsync(id);
            if (cotacao == null)
                return NotFound();

            return Ok(cotacao);
        }

        [HttpPost]
        public async Task<ActionResult<Cotacao>> Create(Cotacao cotacao)
        {
            var novaCotacao = await _cotacaoService.CreateAsync(cotacao);
            return CreatedAtAction(nameof(GetById), new { id = novaCotacao.IdCotacao }, novaCotacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cotacao cotacao)
        {
            var atualizado = await _cotacaoService.UpdateAsync(id, cotacao);
            if (!atualizado)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _cotacaoService.DeleteAsync(id);
            if (!deletado)
                return NotFound();

            return NoContent();
        }
    }

    
}
