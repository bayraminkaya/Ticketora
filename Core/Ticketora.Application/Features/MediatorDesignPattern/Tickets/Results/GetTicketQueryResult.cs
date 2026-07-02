using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Results
{
    public class GetTicketQueryResult
    {
        public int TicketId { get; set; }
        public string TicketNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsUsed { get; set; }
    }
}
