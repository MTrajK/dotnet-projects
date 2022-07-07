namespace DotNet.IntegrationTesting.Demo3.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using DotNet.IntegrationTesting.Demo3.Application.IService;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NotesController : Controller
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public IActionResult GetNoteById(long noteId)
        {
            return Ok(_notesService.GetNoteById(noteId));
        }

        [HttpPost]
        public IActionResult SaveNote(string note)
        {
            return Ok(_notesService.SaveNote(note));
        }
    }
}
