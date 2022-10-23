
using System.ComponentModel.DataAnnotations.Schema;


namespace Flights.Model.Models
{
    [Table("Airports")]
    public class Airport
    {
        public int Id { get; set; } // id
        public string Address { get; set; } = string.Empty;
    }
}
