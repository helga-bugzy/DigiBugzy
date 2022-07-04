
global using DigiBugzy.Core.Domain.Administration.Notes;

namespace DigiBugzy.Services.Administration.Notes
{
    public interface INoteService
    {
        public Note GetById(int id);

        public List<Note> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete = false);

        public void Update(Note entity);

        public void Create(Note entity);
    }
}
