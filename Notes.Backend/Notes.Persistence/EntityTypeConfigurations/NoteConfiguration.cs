﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;


namespace Notes.Persistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<NoteModel>
    {
        public void Configure(EntityTypeBuilder<NoteModel> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id);
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
