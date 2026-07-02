using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.MediatorDesignPattern.Participants.Commands;
using Ticketora.Domain.Entities;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.MediatorDesignPattern.Participants.Handlers
{
    public class CreateParticipantCommandHandler : IRequestHandler<CreateParticipantCommand>
    {
        private readonly TicketoraContext _context;
        public CreateParticipantCommandHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            var participant = new Participant
            {
                Attended = request.Attended,
                CheckInDate = request.CheckInDate,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Surname = request.Surname
            };
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
        }
    }
}
