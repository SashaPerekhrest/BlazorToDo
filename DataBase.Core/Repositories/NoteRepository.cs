using DataBase.Core.Entites;
using Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Core.Repositories
{
    public class NoteRepository
    {
        private readonly NoteStoreDbContext _dbContext;
        public NoteRepository(NoteStoreDbContext context) 
        {
            _dbContext = context;
        }

        public async Task<List<Note>> Get()
        {
            var noteEntities = await _dbContext.Notes
                .AsNoTracking()
                .ToListAsync();

            var notes = noteEntities
                .Select(n => Note.Create(n.Id, n.Title, n.Description, n.CreatedDate).Note)
                .ToList();

            return notes;
        }

        public async Task<Guid> Create(Note note)
        {
            var noteEntity = new NoteEntity
            {
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
                CreatedDate = note.CreatedDate
            };

            await _dbContext.Notes.AddAsync(noteEntity);
            await _dbContext.SaveChangesAsync();

            return noteEntity.Id;

        }
    }
}
