using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestRoom>>> GetSearch(
            int? SubjectId
            )
        {
            var query = _context.Quests.AsQueryable();

            if (SubjectId != null)
            {
                query = query.Where(q => q.Subject.Id == SubjectId);
            }
            
            return await query.ToListAsync();

        }


    }
}

