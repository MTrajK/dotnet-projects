namespace DotNet.MCP.Notes.WebAPI.Controllers
{
    using DotNet.MCP.Notes.Application.Services;
    using DotNet.MCP.Notes.Shared.DTOs;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;

        public NotesController(INoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteResponse>>> GetAll()
        {
            var notes = await _service.GetAllAsync();
            return Ok(notes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<NoteResponse>> GetById(int id)
        {
            var note = await _service.GetByIdAsync(id);
            if (note is null) {
                return NotFound();
            }
            return Ok(note);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<NoteResponse>>> Search([FromQuery] string query)
        {
            var notes = await _service.SearchAsync(query);
            return Ok(notes);
        }

        [HttpPost]
        public async Task<ActionResult<NoteResponse>> Create([FromBody] CreateNoteRequest request)
        {
            var note = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteRequest request)
        {
            var updated = await _service.UpdateAsync(request);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
