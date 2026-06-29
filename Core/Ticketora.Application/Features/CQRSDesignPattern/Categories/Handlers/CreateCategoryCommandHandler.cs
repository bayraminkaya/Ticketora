using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Commands;
using Ticketora.Domain.Entities;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.CQRSDesignPattern.Categories.Handlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly TicketoraContext _context;

        public CreateCategoryCommandHandler(TicketoraContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            var category = new Category()
            {
                CategoryName = command.CategoryName
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
    }

}
