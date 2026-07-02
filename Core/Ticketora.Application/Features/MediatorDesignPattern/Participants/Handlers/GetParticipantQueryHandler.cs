using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.MediatorDesignPattern.Participants.Queries;
using Ticketora.Application.Features.MediatorDesignPattern.Participants.Results;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.MediatorDesignPattern.Participants.Handlers
{
    public class GetParticipantsQueryHandler : IRequestHandler<GetParticipantQuery, List<GetParticipantQueryResult>>
    {
        private readonly TicketoraContext _context;
        public GetParticipantsQueryHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task<List<GetParticipantQueryResult>> Handle(GetParticipantQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Participants
                .Select(x => new GetParticipantQueryResult
                {
                    Attended = x.Attended,
                    CheckInDate = x.CheckInDate,
                    Email = x.Email,
                    Name = x.Name,
                    ParticipantId = x.ParticipantId,
                    PhoneNumber = x.PhoneNumber,
                    Surname = x.Surname
                }).ToListAsync();

            return values;
        }
    }
}
