using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteAPI.DBContext;
using NoteAPI.Models;

namespace NoteAPI.Controllers.Notes
{
    [Route("api/note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public NoteController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var list = await _context.Notes.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(Guid id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteRequest request)
        {
            var note = new NoteModel
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.Now,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Admin"
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Note create successfully" });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] NoteRequest request)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            note.Title = request.Title ?? note.Title;
            note.Content = request.Content ?? note.Content;
            note.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Note update successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Note delete successfully" });
        }
    }
}
