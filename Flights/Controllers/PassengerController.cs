using Flights.BusinessLogic.Interfaces;
using Flights.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : Controller
    {

        private readonly IPassengerService _passengerService;
        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }
        [Route("passengers")]
        public ActionResult Passengers(int passengers, int idFlight)
        {
            ViewBag.Passengers = passengers;
            ViewBag.IdFlight = idFlight;
            return View("~/Pages/Passenger.cshtml");
        }

    }
}
