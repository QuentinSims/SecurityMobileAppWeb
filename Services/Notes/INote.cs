using SecurityMobileAppWeb.Models;

namespace SecurityMobileAppWeb.Services.Notes
{
    public interface INote
    {
        Task AddNoteAsync(Note note);
        Task DeleteNoteAsync(string id);
        Task<IEnumerable<Note>> GetAllNotesAsync();
    }
}
