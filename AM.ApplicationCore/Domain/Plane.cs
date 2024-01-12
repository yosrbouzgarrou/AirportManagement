using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,Airbus
    }
    public class Plane
    {
        public Plane()
        {

        }
        public Plane(int capacity, int planeId, DateTime manufactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            PlaneId = planeId;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
        }

        //propriétés de base
        [NotMapped]
        public string Information { get { return PlaneId + " " + ManufactureDate + " " + Capacity; } }
        [Range(0,int.MaxValue)]
        public int Capacity { get; set; }
        public int PlaneId { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }
        // prop de navigation
        public virtual List<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "Capacity ="+ Capacity+
            "PlaneId ="+ PlaneId+
            "ManufactureDate ="+ ManufactureDate+
            "PlaneType = "+PlaneType;

        }
    }
}
