using Microsoft.EntityFrameworkCore;
using Note.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Persistence
{
    public class NoteDbContext : DbContext, INotesDbContext
    {
        public DbSet<NoteModel> Notes { get ; set; }

        public NoteDbContext(DbContextOptions<NoteDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
