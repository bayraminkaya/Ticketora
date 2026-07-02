using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Commands;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Handlers
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly TicketoraContext _context;

        public UpdateTicketCommandHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Tickets.FindAsync(request.TicketId);

            value.TicketNumber = request.TicketNumber;
            value.Price = request.Price;
            value.PurchaseDate = request.PurchaseDate;
            value.IsUsed = request.IsUsed;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}