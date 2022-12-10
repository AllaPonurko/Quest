using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Models;

namespace Quest.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiQuestRoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiQuestRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiQuestRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestRoom>>> GetQuests()
        {
            return await _context.Quests.ToListAsync();
        }

        // GET: api/ApiQuestRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestRoom>> GetQuestRoom(int id)
        {
            var questRoom = await _context.Quests.FindAsync(id);

            if (questRoom == null)
            {
                return NotFound();
            }

            return questRoom;
        }

        // PUT: api/ApiQuestRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestRoom(int id, QuestRoom questRoom)
        {
            if (id != questRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(questRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestRoomExists(id))
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

        // POST: api/ApiQuestRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestRoom>> PostQuestRoom(QuestRoom questRoom)
        {
            _context.Quests.Add(questRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestRoom", new { id = questRoom.Id }, questRoom);
        }

        // DELETE: api/ApiQuestRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestRoom(int id)
        {
            var questRoom = await _context.Quests.FindAsync(id);
            if (questRoom == null)
            {
                return NotFound();
            }

            _context.Quests.Remove(questRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestRoomExists(int id)
        {
            return _context.Quests.Any(e => e.Id == id);
        }
    }
}
