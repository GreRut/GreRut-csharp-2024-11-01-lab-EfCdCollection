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

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CD>>> GetCDs()
        {
            return await _context.CDs.ToListAsync();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<CD>> PostAddress(int id, string name, string artistName, string description)
//         {
//             var CDRequest = new CD(){
//                 Id = id,
//                 Name = name,
//                 ArtistName = artistName,
//                 Description = description,
//                 PurchaseDate = DateTime.Now,
//             };

//            _context.CDs.Add(CDRequest);
//             await _context.SaveChangesAsync();     

//             return CreatedAtAction("GetAddress", new { id = CDRequest.Id }, CDRequest);
//         }

    }
}