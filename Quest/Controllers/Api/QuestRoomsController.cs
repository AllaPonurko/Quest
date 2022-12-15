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
    public class QuestRoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiQuestRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestRoom>>> GetQuests(int? SubjectId)
        {
            var query = _context.Quests.AsQueryable();
            if (SubjectId != null)
            {
                query = query.Where(q => q.Subject.Id == SubjectId);
            }
            return await query.ToListAsync();
            //return await _context.Quests.ToListAsync();
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

        //private bool QuestRoomExists(int id)
        //{
        //    return _context.Quests.Any(e => e.Id == id);
        //}
    }
}
