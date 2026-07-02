using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Queries;
using Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Results;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Handlers
{
    public class GetByIdTicketQueryHandler:IRequestHandler<GetByIdTicketQuery,GetByIdTicketQueryResult>
    {
        private readonly TicketoraContext _context;

        public GetByIdTicketQueryHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task<GetByIdTicketQueryResult> Handle(GetByIdTicketQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Tickets
                .Where(x => x.TicketId == request.Id)
                .Select(x => new GetByIdTicketQueryResult
                {
                    TicketId = x.TicketId,
                    TicketNumber = x.TicketNumber,
                    Price = x.Price,
                    PurchaseDate = x.PurchaseDate,
                    IsUsed = x.IsUsed
                }).FirstOrDefaultAsync();

            return value;
        }
    }
}
