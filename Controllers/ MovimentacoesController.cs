using System;

using Microsoft.AspNetCore.Mvc;
using CheckInOutMotosApi.Data;
using CheckInOutMotosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckInOutMotosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovimentacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimentacao>>> Get()
        {
            return await _context.Movimentacoes
                .Include(m => m.Moto)
                .Include(m => m.Patio)
                .ToListAsync();
        }

        [HttpPost("checkin")]
        public async Task<ActionResult<Movimentacao>> CheckIn(Movimentacao movimentacao)
        {
            movimentacao.DataHora = DateTime.Now;
            movimentacao.Tipo = "Check-in";
            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movimentacao.Id }, movimentacao);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<Movimentacao>> CheckOut(Movimentacao movimentacao)
        {
            movimentacao.DataHora = DateTime.Now;
            movimentacao.Tipo = "Check-out";
            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movimentacao.Id }, movimentacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao == null)
                return NotFound();

            _context.Movimentacoes.Remove(movimentacao);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

