using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Queries;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Results;
using Ticketora.Persistence.Context;

namespace Ticketora.Application.Features.CQRSDesignPattern.Categories.Handlers
{
    public class GetByIdCategoryQueryHandler
    {
        private readonly TicketoraContext _context;

        public GetByIdCategoryQueryHandler(TicketoraContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetByIdCategoryQuery query)
        {
            var value = await _context.Categories.FindAsync(query.Id);

            return new GetCategoryByIdQueryResult
            {
                CategoryId = value.CategoryId,
                CategoryName = value.CategoryName

            };
        }
    }
}
