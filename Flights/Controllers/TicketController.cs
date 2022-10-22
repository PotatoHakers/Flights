using Flights.BusinessLogic.Interfaces;
using Flights.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly IPassengerService _passengerService;
        private readonly ITicketService _ticketService;
        private readonly IBuyerService _buyerService;
        public TicketController(IPassengerService passengerService, ITicketService ticketService, IBuyerService buyerService)
        {
            _passengerService = passengerService;
            _ticketService = ticketService;
            _buyerService = buyerService;
        }

        [HttpPost]
        public ActionResult Create([FromForm] PassengerDto[] passengers, [FromForm]BuyerDto buyer, [FromForm] int idFlight)
        {
            _buyerService.Create(buyer);
            foreach (var item in passengers)
            {
                _passengerService.Create(item);
                TicketDto ticket = new TicketDto {Buyer=buyer, Passenger = item, FlightId = idFlight };
                _ticketService.Create(ticket);
            }

            ViewBag.IdFlight = idFlight;

            return View("~/Pages/Passenger.cshtml");
        }
    }
}
