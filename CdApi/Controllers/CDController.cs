using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CdApi.Data;
using CdApi.Models;
using System.Linq;

namespace CdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CDsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CD>>> GetCDs()
        {
            return await _context.CDs.ToListAsync();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<CD>>> SearchGenre(string? genre)
        {
            if (genre != null)
            {
                return await _context.CDs.Where(u => u.ArtistName.ToLower().Contains(genre.ToLower())).ToListAsync();
            }
            else
                return await _context.CDs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CD>> GetCD(int id)
        {
            var cds = await _context.CDs.FindAsync(id);

            if (cds == null)
            {
                return NotFound();
            }

            return cds;
        }

        [HttpPost]
        public async Task<ActionResult<CD>> PostAddress(string name, string artistName, string description)
        {
            var CDRequest = new CD()
            {
                Name = name,
                ArtistName = artistName,
                Description = description,
                PurchaseDate = DateTime.Now,
            };

            _context.CDs.Add(CDRequest);
            await _context.SaveChangesAsync();

            var CDResponse = new CDResponse
            {

                name = CDRequest.Name,
                artistName = CDRequest.ArtistName,
                description = CDRequest.Description
            };

            return CreatedAtAction("GetCD", new { id = CDRequest.Id }, CDResponse);
        }

        [HttpPatch("{id}/artistName")]
        public async Task<IActionResult> AddArtistToCD(int id, string artistName)
        {
            var cd = await _context.CDs.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }

            cd.ArtistName = artistName;

            _context.Entry(cd).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}