using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardAPI.Models;
using CardAPI.Data;


namespace CardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardDecorationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CardDecorationsController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.CardDecorations.Include(c => c.User).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var card = await _context.CardDecorations.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
            return card == null ? NotFound() : Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CardDecoration card)
        {
            _context.CardDecorations.Add(card);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = card.Id }, card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CardDecoration card)
        {
            if (id != card.Id) return BadRequest();
            _context.Entry(card).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var card = await _context.CardDecorations.FindAsync(id);
            if (card == null) return NotFound();
            _context.CardDecorations.Remove(card);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}