using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Note.Application.Notes.Commands.CreateNote;
using Note.Application.Notes.Commands.DeleteNote;
using Note.Application.Notes.Commands.UpdateNote;
using Note.Application.Notes.Queries.GetNoteDetails;
using Note.Application.Notes.Queries.GetNoteList;
using Notes.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NoteController:BaseController
    {
        private readonly IMapper _mapper;
        public NoteController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNote([FromBody]CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand {
                Id=id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
