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
    public class RemoveParticipantCommandHandler : IRequestHandler<RemoveParticipantCommand>
    {
        private readonly TicketoraContext _context;
        public RemoveParticipantCommandHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveParticipantCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Participants.FindAsync(request.Id);
            _context.Participants.Remove(value);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
