using System;

using Microsoft.AspNetCore.Mvc;
using CheckInOutMotosApi.Data;
using CheckInOutMotosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckInOutMotosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MotosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> Get()
        {
            return await _context.Motos.Include(m => m.Cliente).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> Get(int id)
        {
            var moto = await _context.Motos.Include(m => m.Cliente).FirstOrDefaultAsync(m => m.Id == id);
            if (moto == null)
                return NotFound();

            return moto;
        }

        [HttpPost]
        public async Task<ActionResult<Moto>> Post(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = moto.Id }, moto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Moto moto)
        {
            if (id != moto.Id)
                return BadRequest();

            _context.Entry(moto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
