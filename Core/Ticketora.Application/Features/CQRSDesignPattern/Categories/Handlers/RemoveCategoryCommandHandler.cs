using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Commands;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.CQRSDesignPattern.Categories.Handlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly TicketoraContext _context;

        public RemoveCategoryCommandHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.CategoryId);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
