namespace DotNet.IntegrationTesting.Demo3.IntegrationTests.Controllers
{
    using System.Net;
    using Xunit;

    using DotNet.IntegrationTesting.Demo3.IntegrationTests.Setup;
    using DotNet.IntegrationTesting.Demo3.API;
    using DotNet.IntegrationTesting.Demo3.IntegrationTests.Utils;

    public class NotesControllerTests : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private static HttpClient _sut;

        private const string _getNoteByIdUri = "/api/Notes/GetNoteById?noteId={0}";
        private const string _saveNoteUri = "/api/Notes/SaveNote?note={0}";

        public NotesControllerTests(TestWebApplicationFactory<Startup> factory)
        {
            _sut = factory.CreateClient();
        }

        [Fact]
        public async Task SaveNote_RandomNote_ReturnsSuccess()
        {
            // Arrange
            var note = "Random Note";
            var uri = string.Format(_saveNoteUri, note);

            //Act
            var response = await _sut.PostAsync(uri, null);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetNoteById_GetSavedNote_ReturnsSavedNote()
        {
            // Arrange
            var note = "Saved Note";
            var saveNoteUri = string.Format(_saveNoteUri, note);

            var savedNoteResponse = await _sut.PostAsync(saveNoteUri, null);
            var savedNoteId = await savedNoteResponse.Content.ReadAsInt();

            var getNoteUri = string.Format(_getNoteByIdUri, savedNoteId);

            //Act
            var response = await _sut.GetAsync(getNoteUri);

            // Assert
            var responseValue = await response.Content.ReadAsStringAsync();
            Assert.Equal(note, responseValue);
        }
    }
}
