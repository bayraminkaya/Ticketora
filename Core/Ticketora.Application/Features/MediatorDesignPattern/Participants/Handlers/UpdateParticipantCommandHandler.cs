using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.MediatorDesignPattern.Participants.Commands;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.MediatorDesignPattern.Participants.Handlers
{
    public class UpdateParticipantCommandHandler : IRequestHandler<UpdateParticipantCommand>
    {
        private readonly TicketoraContext _context;
        public UpdateParticipantCommandHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateParticipantCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Participants.FindAsync(request.ParticipantId);
            value.Surname = request.Surname;
            value.PhoneNumber = request.PhoneNumber;
            value.ParticipantId = request.ParticipantId;
            value.Attended = request.Attended;
            value.CheckInDate = request.CheckInDate;
            value.Email = request.Email;
            value.Name = request.Name;
            await _context.SaveChangesAsync();
        }
    }
}
