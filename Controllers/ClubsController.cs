using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballLeagueServer.Models;

namespace FootballLeagueServer.Controllers
{
    [Route("")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly ClubContext _context;

        public ClubsController(ClubContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Retrieves all clubs.
        /// </summary>
        /// <param name="id"></param> 
        // GET: api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            return await _context.Clubs.ToListAsync();
        }
        /// <summary>
        /// Retrieves a specific club.
        /// </summary>
        /// <param name="id"></param> 
        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(string id)
        {
            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return club;
        }
        /// <summary>
        /// Creates a new club.
        /// </summary>
        /// <param name="id"></param> 
        // PUT: api/Clubs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub(string id, Club club)
        {
            if (id != club.Name)
            {
                return BadRequest();
            }

            _context.Entry(club).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
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
        /// <summary>
        /// Adds a new club.
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///     
        ///     POST /Club
        ///     {
        ///         Name = "Valencia",
        ///         Position = 1,
        ///         GoalDifference = +100,
        ///         Points = 444
        ///         }
        /// 
        /// 
        /// </remarks>
        // POST: api/Clubs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Club>> PostClub(Club club)
        {
            _context.Clubs.Add(club);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClubExists(club.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            if (PosExists(club.Position)){
                return Conflict();
            }
            if (club.Position > 20 || club.Position < 1 || club.Position%1 != 0)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(GetClub), new { id = club.Name }, club);
        }
        /// <summary>
        /// Deletes a specific club.
        /// </summary>
        /// <param name="id"></param> 
        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Club>> DeleteClub(string id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return club;
        }

        private bool ClubExists(string id)
        {
            return _context.Clubs.Any(e => e.Name == id);
        }

        private bool PosExists(int pos)
        {
            return _context.Clubs.Any(e => e.Position == pos);
        }
    }
}
