using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Commands;
using Ticketora.Application.Features.CQRSDesignPattern.Events.Commands;
using Ticketora.Domain.Entities;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.CQRSDesignPattern.Events.Handlers
{
    public class CreateEventCommandHandler
{
    private readonly TicketoraContext _context;

    public CreateEventCommandHandler(TicketoraContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateEventCommand command)
    {
        var value = new Event()
        {
            Description = command.Description,
            EventDate = command.EventDate,
            ImageUrl = command.ImageUrl,
            Location = command.Location,
            Price = command.Price,
            Status = command.Status,
            Title = command.Title
        };

        await _context.Events.AddAsync(value);
        await _context.SaveChangesAsync();
    }
}
}
