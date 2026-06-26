using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Results;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.CQRSDesignPattern.Categories.Handlers
{
    public class GetCategoryQueryHandler
    {
        public readonly TicketoraContext _context;

        public GetCategoryQueryHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _context.Categories
                .Select(x => new GetCategoryQueryResult
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                }).ToListAsync();

            return values;
        }
    }
}
