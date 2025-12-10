using DotNet.MCP.Notes.Shared.DTOs;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Reflection;
using static System.Net.WebRequestMethods;

/// <summary>
/// Sample MCP tools for demonstration purposes.
/// These tools can be invoked by MCP clients to perform various operations.
/// </summary>
namespace DotNet.MCP.Notes.MCPServer.Tools
{
    public class NotesAppTools
    {
        private const string GetAllNotesApiUrl = "api/notes";
        private const string SearchNotesApiUrl = "api/notes/search?query={0}";
        private const string CreateNoteApiUrl = "api/notes";
        private const string UpdateNoteApiUrl = "api/notes";
        private const string DeleteNoteApiUrl = "api/notes/{0}";

        [McpServerTool]
        [Description("Returns all the notes from the Notes APP with these 3 atributes for each of the notes: Id, Title, Description.")]
        public async Task<List<NoteResponse>?> GetAllNotes(HttpClient httpClient)
        {
            var notes = await httpClient.GetFromJsonAsync<List<NoteResponse>>(GetAllNotesApiUrl);
            return notes;
        }

        [McpServerTool]
        [Description("Returns all the notes from the Notes APP that contains the search query in the Title or the Description, for each of the notes these 3 atributes are returned: Id, Title, Description.")]
        public async Task<List<NoteResponse>?> SearchNotes(HttpClient httpClient,
            [Description("Search query")] string searchQuery = "")
        {
            var url = string.Format(SearchNotesApiUrl, Uri.EscapeDataString(searchQuery));
            var notes = await httpClient.GetFromJsonAsync<List<NoteResponse>>(url);
            return notes;
        }

        [McpServerTool]
        [Description("Creates a note with Title and Description in the Notes APP.")]
        public async Task<string> CreateNote(HttpClient httpClient,
            [Description("Note title")] string title,
            [Description("Note description")] string description)
        {
            var createNoteRequest = new CreateNoteRequest() { 
                Title = title,
                Description = description
            };
            var response = await httpClient.PostAsJsonAsync(CreateNoteApiUrl, createNoteRequest);
            if (response.IsSuccessStatusCode)
            {
                return "Success: The note is created.";
            }

            return "Error: The note was not created.";
        }

        [McpServerTool]
        [Description("Updates a note with Title and Description in the Notes APP, the note Id is used to match the note that needs to be updated.")]
        public async Task<string> UpdateNote(HttpClient httpClient,
            [Description("Note id")] int id,
            [Description("Note title")] string title,
            [Description("Note description")] string description)
        {
            var updateNoteRequest = new UpdateNoteRequest()
            {
                Id = id,
                Title = title,
                Description = description
            };
            var response = await httpClient.PutAsJsonAsync(UpdateNoteApiUrl, updateNoteRequest);
            if (response.IsSuccessStatusCode)
            {
                return "Success: The note is update.";
            }

            return "Error: The note was not updated.";
        }

        [McpServerTool]
        [Description("Deletes a note from the Notes APP, the note Id is used to match the note that needs to be deleted.")]
        public async Task<string> DeleteNote(HttpClient httpClient,
            [Description("Note id")] int id)
        {
            var url = string.Format(DeleteNoteApiUrl, id);
            var response = await httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return "Success: The note is deleted.";
            }

            return "Error: The note was not deleted.";
        }
    }
}
