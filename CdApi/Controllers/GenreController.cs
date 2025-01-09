using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CdApi.Data;
using CdApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(string name)
        {
            var genreRequest = new Genre()
            {
                Name = name,
            };

            _context.Genres.Add(genreRequest);
            await _context.SaveChangesAsync();     

            // Return the response with the correct variable
            return CreatedAtAction("GetGenres", new { id = genreRequest.Id }, genreRequest);
        }
    }
}