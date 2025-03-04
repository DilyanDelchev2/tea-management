using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeaManagmentSystem2.Data;
using TeaManagmentSystem2.Models;
namespace TeaManagmentSystem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeaController : ControllerBase
    {
        private readonly TeaManagementContext _context;

        public TeaController(TeaManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tea>>> GetTeas()
        {
            return await _context.Teas.Include(t => t.Supplier).Include(t => t.Category).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tea>> GetTea(int id)
        {
            var tea = await _context.Teas.Include(t => t.Supplier).Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);

            if (tea == null)
            {
                return NotFound();
            }

            return tea;
        }

        [HttpPost]
        public async Task<ActionResult<Tea>> CreateTea(Tea tea)
        {
            _context.Teas.Add(tea);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTea), new { id = tea.Id }, tea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTea(int id, Tea tea)
        {
            if (id != tea.Id)
            {
                return BadRequest();
            }

            _context.Entry(tea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Teas.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTea(int id)
        {
            var tea = await _context.Teas.FindAsync(id);

            if (tea == null)
            {
                return NotFound();
            }

            _context.Teas.Remove(tea);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
