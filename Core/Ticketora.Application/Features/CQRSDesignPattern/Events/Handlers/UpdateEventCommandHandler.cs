using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.CQRSDesignPattern.Events.Commands;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.CQRSDesignPattern.Events.Handlers
{
    public class UpdateEventCommandHandler
    {
        private readonly TicketoraContext _context;

        public UpdateEventCommandHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateEventCommand command)
        {
            var value = await _context.Events.FindAsync(command.EventId);

            if (value != null)
            {
                value.Title = command.Title;
                value.Description = command.Description;
                value.Location = command.Location;
                value.EventDate = command.EventDate;
                value.Price = command.Price;
                value.ImageUrl = command.ImageUrl;
                value.Status = command.Status;

                await _context.SaveChangesAsync();
            }
        }
    }
}
