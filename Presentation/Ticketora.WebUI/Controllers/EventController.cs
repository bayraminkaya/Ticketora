using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ticketora.Application.Features.CQRSDesignPattern.Events.Commands;
using Ticketora.Application.Features.CQRSDesignPattern.Events.Handlers;
using Ticketora.Application.Features.CQRSDesignPattern.Events.Queries;

namespace Ticketora.WebUI.Controllers
{
    public class EventController : Controller
    {
        private readonly GetEventQueryHandler _getEventQueryHandler;
        private readonly GetByIdEventQueryHandler _getByIdEventQueryHandler;
        private readonly CreateEventCommandHandler _createEventCommandHandler;
        private readonly UpdateEventCommandHandler _updateEventCommandHandler;
        private readonly RemoveEventCommandHandler _removeEventCommandHandler;

        public EventController(GetEventQueryHandler getEventQueryHandler, GetByIdEventQueryHandler getByIdEventQueryHandler, 
            CreateEventCommandHandler createEventCommandHandler, UpdateEventCommandHandler updateEventCommandHandler, 
            RemoveEventCommandHandler removeEventCommandHandler)

        {
            _getEventQueryHandler = getEventQueryHandler;
            _getByIdEventQueryHandler = getByIdEventQueryHandler;
            _createEventCommandHandler = createEventCommandHandler;
            _updateEventCommandHandler = updateEventCommandHandler;
            _removeEventCommandHandler = removeEventCommandHandler;
        }

        public async Task<IActionResult> EventList()
        {
            var values = await _getEventQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventCommand command)
        {
            command.Status = true;
            await _createEventCommandHandler.Handle(command);
            return RedirectToAction("EventList");
        }

        [HttpGet]
        public async Task<IActionResult> Updatelist(int id)
        {
            var value = await _getByIdEventQueryHandler.Handle(new GetByIdEventQuery());
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateResult(UpdateEventCommand command)
        {
            await _updateEventCommandHandler.Handle(command);
            return RedirectToAction("EventList");
        }
    }
}
