
using System.ComponentModel.DataAnnotations.Schema;


namespace Flights.Common.Dto
{
    public class BuyerDto:PersonDto
    {
        public string Phone { get; set; } = string.Empty;
        public string TimeToConnect { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;


    }
}
