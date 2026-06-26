using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Commands;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.CQRSDesignPattern.Categories.Handlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly TicketoraContext _context;

        public UpdateCategoryCommandHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.CategoryId);
            category.CategoryName = command.CategoryName;
            await _context.SaveChangesAsync();
        }
    }
}
