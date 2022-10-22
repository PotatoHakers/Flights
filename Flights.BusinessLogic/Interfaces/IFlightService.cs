using Flights.Common.Dto;
namespace Flights.BusinessLogic.Interfaces
{
    public interface IFlightService
    {
        FlightDto Get(int id);
        IEnumerable<FlightDto> Get(FlightFindDto model);
        void Create(FlightDto model);
        void Update();
        void Delete(int id);
    }
}
