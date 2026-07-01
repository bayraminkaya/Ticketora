using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.MediatorDesignPattern.Commands;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.MediatorDesignPattern.Handlers
{
    public class RemoveTicketCommandHandler: IRequestHandler<RemoveTicketCommand>
    {
        private readonly TicketoraContext _context;
        public RemoveTicketCommandHandler(TicketoraContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveTicketCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Tickets.FindAsync(request.Id);
            _context.Tickets.Remove(value);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
