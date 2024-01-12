using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        //prop+2tab
        public int FlightId { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string AirlineLogo { get; set; }
       
        public int? PlaneId { get; set; }//?: nullable
        // prop de navigation
        [ForeignKey("PlaneId")]
        public virtual Plane Plane { get; set; }
        public virtual List<Passenger> Passengers { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return "FlightId = "+ FlightId+
                " , Destination "+ Destination+
                " , Departure = " + Departure+
                " , FlightDate = "+ FlightDate+
                " , EstimatedDuration = "+ EstimatedDuration+
                " , EffectiveArrival = "+ EffectiveArrival;
        }

    }
}
