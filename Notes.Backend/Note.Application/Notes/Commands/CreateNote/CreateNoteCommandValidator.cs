using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator:AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteComand => createNoteComand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand => createNoteCommand.UserId).NotEqual(Guid.Empty);
        }

    }
}
