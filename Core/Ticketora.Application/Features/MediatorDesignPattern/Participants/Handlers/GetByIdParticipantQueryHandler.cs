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
    public class GetByIdParticipantQueryHandler : IRequestHandler<GetByIdParticipantQuery, GetByIdParticipantQueryResult>
    {
        private readonly TicketoraContext _context;
        public GetByIdParticipantQueryHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task<GetByIdParticipantQueryResult> Handle(GetByIdParticipantQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Participants
                .Where(x => x.ParticipantId == request.Id)
                .Select(x => new GetByIdParticipantQueryResult
                {
                    Attended = x.Attended,
                    CheckInDate = x.CheckInDate,
                    Email = x.Email,
                    Name = x.Name,
                    ParticipantId = x.ParticipantId,
                    PhoneNumber = x.PhoneNumber,
                    Surname = x.Surname
                }).FirstOrDefaultAsync();

            return value;
        }
    }
}
