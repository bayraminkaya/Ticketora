using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticketora.Application.Features.MediatorDesignPattern.Participants.Commands;
using Ticketora.Application.Features.MediatorDesignPattern.Participants.Queries;

namespace Ticketora.WebUI.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly IMediator _mediator;
        public ParticipantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> ParticipantList()
        {
            var values = await _mediator.Send(new GetParticipantQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateParticipant()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant(CreateParticipantCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("ParticipantList");
        }
    }
}
