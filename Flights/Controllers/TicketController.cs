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
        private readonly IFlightService _flightService;
        public TicketController(IPassengerService passengerService, ITicketService ticketService, IBuyerService buyerService, IFlightService flightService)
        {
            _passengerService = passengerService;
            _ticketService = ticketService;
            _buyerService = buyerService;
            _flightService = flightService;
        }

        [HttpPost]
        public ActionResult Create([FromForm] List<PassengerDto> passengers, [FromForm]BuyerDto buyer, [FromForm] int idFlight)
        {
            _buyerService.Create(buyer);
            _flightService.UpdateSeats(idFlight, passengers.Count);
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
