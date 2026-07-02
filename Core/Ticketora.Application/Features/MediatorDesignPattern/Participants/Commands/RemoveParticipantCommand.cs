using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketora.Application.Features.MediatorDesignPattern.Participants.Commands
{
    public class RemoveParticipantCommand :IRequest
    {
        public int Id { get; set; }

        public RemoveParticipantCommand(int id)
        {
            Id = id;
        }
    }
}
