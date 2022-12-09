using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Models;

namespace Quest.Controllers
{
    public class QuestRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestRooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Quests.Include(q => q.Subject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuestRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questRoom = await _context.Quests
                .Include(q => q.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questRoom == null)
            {
                return NotFound();
            }

            return View(questRoom);
        }

        // GET: QuestRooms/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        // POST: QuestRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SubjectId,Time,LevelOfFear,DifficultyLevel,NumberOfPlayers")] QuestRoom questRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", questRoom.SubjectId);
            return View(questRoom);
        }

        // GET: QuestRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questRoom = await _context.Quests.FindAsync(id);
            if (questRoom == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", questRoom.SubjectId);
            return View(questRoom);
        }

        // POST: QuestRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SubjectId,Time,LevelOfFear,DifficultyLevel,NumberOfPlayers")] QuestRoom questRoom)
        {
            if (id != questRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestRoomExists(questRoom.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", questRoom.SubjectId);
            return View(questRoom);
        }

        // GET: QuestRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questRoom = await _context.Quests
                .Include(q => q.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questRoom == null)
            {
                return NotFound();
            }

            return View(questRoom);
        }

        // POST: QuestRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questRoom = await _context.Quests.FindAsync(id);
            _context.Quests.Remove(questRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestRoomExists(int id)
        {
            return _context.Quests.Any(e => e.Id == id);
        }
    }
}
