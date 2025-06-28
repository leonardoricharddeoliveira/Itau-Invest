using Itau_invest.Models;
using Itau_invest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau_invest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PosicaoController : ControllerBase
    {
        private readonly PosicaoService _posicaoService;

        public PosicaoController(PosicaoService posicaoService)
        {
            _posicaoService = posicaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posicao>>> GetAll()
        {
            var posicoes = await _posicaoService.GetAllAsync();
            return Ok(posicoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Posicao>> GetById(int id)
        {
            var posicao = await _posicaoService.GetByIdAsync(id);
            if (posicao == null)
                return NotFound();

            return Ok(posicao);
        }

        [HttpPost]
        public async Task<ActionResult<Posicao>> Create(Posicao posicao)
        {
            var novaPosicao = await _posicaoService.CreateAsync(posicao);
            return CreatedAtAction(nameof(GetById), new { id = novaPosicao.IdPosicao }, novaPosicao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Posicao posicao)
        {
            var atualizado = await _posicaoService.UpdateAsync(id, posicao);
            if (!atualizado)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _posicaoService.DeleteAsync(id);
            if (!deletado)
                return NotFound();

            return NoContent();
        }

        // Novos endpoints para cálculos
        [HttpGet("preco-medio/{idUsuario}/{idAtivo}")]
        public async Task<ActionResult<decimal>> CalcularPrecoMedio(int idUsuario, int idAtivo)
        {
            var precoMedio = await _posicaoService.CalcularPrecoMedioPonderado(idUsuario, idAtivo);
            return Ok(precoMedio);
        }

        [HttpGet("quantidade/{idUsuario}/{idAtivo}")]
        public async Task<ActionResult<decimal>> CalcularQuantidadeAtual(int idUsuario, int idAtivo)
        {
            var qtd = await _posicaoService.CalcularQuantidadeAtual(idUsuario, idAtivo);
            return Ok(qtd);
        }

        [HttpGet("pl/{idUsuario}/{idAtivo}")]
        public async Task<ActionResult<decimal>> CalcularPL(int idUsuario, int idAtivo)
        {
            var pl = await _posicaoService.CalcularPL(idUsuario, idAtivo);
            return Ok(pl);
        }

        [HttpGet("corretagem/{idUsuario}")]
        public async Task<ActionResult<decimal>> CalcularCorretagem(int idUsuario)
        {
            var total = await _posicaoService.CalcularTotalCorretagem(idUsuario);
            return Ok(total);
        }
    }
}
