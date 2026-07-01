using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticketora.Application.Features.MediatorDesignPattern.Commands;
using Ticketora.Application.Features.MediatorDesignPattern.Queries;

namespace Ticketora.WebUI.Controllers
{
    public class TicketController : Controller
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> TicketList()
        {
            var values = await _mediator.Send(new GetTicketQuery());
            return View(values);
        }

        public IActionResult CreateTicket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("TicketList");
        }

        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _mediator.Send(new RemoveTicketCommand(id));
            return RedirectToAction("TicketList");
        }

        public async Task<IActionResult> UpdateTicket(int id)
        {
            var value = await _mediator.Send(new GetByIdTicketQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTicket(UpdateTicketCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("TicketList");
        }
    }
}
