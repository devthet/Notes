using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Notes.Domain;

namespace Note.Application.Interfaces
{
    public interface INotesDbContext
    {
        public DbSet<NoteModel> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancelationToken);
    }
}
