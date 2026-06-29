using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketora.Application.Features.CQRSDesignPattern.Events.Queries
{
    public class GetByIdEventQuery
    {
        public int Id { get; set; }
    }
}
