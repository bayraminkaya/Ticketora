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
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, List<GetTicketQueryResult>>
    {
        private readonly TicketoraContext _context;

        public GetTicketQueryHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task<List<GetTicketQueryResult>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Tickets
                .Select(x => new GetTicketQueryResult
                {
                    TicketId = x.TicketId,
                    TicketNumber = x.TicketNumber,
                    Price = x.Price,
                    PurchaseDate = x.PurchaseDate,
                    IsUsed = x.IsUsed
                }).ToListAsync();

            return values;
        }
    }
}
