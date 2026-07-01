using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.MediatorDesignPattern.Results;

namespace Ticketora.Application.Features.MediatorDesignPattern.Queries
{
    public class GetTicketQuery :IRequest<List<GetTicketQueryResult>>
    {
    }
}
