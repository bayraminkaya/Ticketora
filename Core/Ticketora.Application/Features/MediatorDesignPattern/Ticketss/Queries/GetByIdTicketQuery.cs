using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Results;

namespace Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Queries
{
    public class GetByIdTicketQuery : IRequest<GetByIdTicketQueryResult>
    {
        public int Id { get; set; }

        public GetByIdTicketQuery(int id)
        {
            Id = id;
        }
    }
}
