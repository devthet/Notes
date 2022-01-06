using AutoMapper;
using Note.Application.Common.Mappings;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto:IMapWith<NoteModel>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NoteModel, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title, opt => opt.MapFrom(note => note.Title));
        }
    }
}
