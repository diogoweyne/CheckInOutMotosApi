using System;

using Microsoft.AspNetCore.Mvc;
using CheckInOutMotosApi.Data;
using CheckInOutMotosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckInOutMotosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatiosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatiosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> Get()
        {
            return await _context.Patios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> Get(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null)
                return NotFound();

            return patio;
        }

        [HttpPost]
        public async Task<ActionResult<Patio>> Post(Patio patio)
        {
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = patio.Id }, patio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Patio patio)
        {
            if (id != patio.Id)
                return BadRequest();

            _context.Entry(patio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null)
                return NotFound();

            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

