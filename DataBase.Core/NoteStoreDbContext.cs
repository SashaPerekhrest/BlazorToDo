using DataBase.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Core
{
    public class NoteStoreDbContext : DbContext
    {
        public NoteStoreDbContext(DbContextOptions<NoteStoreDbContext> options) : base(options) 
        {}

        public DbSet<NoteEntity> Notes { get; set; }
    }
}
