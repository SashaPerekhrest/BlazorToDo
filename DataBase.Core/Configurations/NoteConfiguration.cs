using DataBase.Core.Entites;
using Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Core.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<NoteEntity>
    {
        public void Configure(EntityTypeBuilder<NoteEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .HasMaxLength(Note.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(e => e.Description)
                .IsRequired();
            builder.Property(e => e.CreatedDate)
                .IsRequired();
        }
    }
}
