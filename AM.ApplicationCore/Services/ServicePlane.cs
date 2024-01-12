using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane :Service<Plane>, IServicePlane
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork):base(unitOfWork)
        {
           _unitOfWork=unitOfWork;
        }

        public bool AvailablePlane(Flight flight, int n)
        {
            return flight.Plane.Capacity >= flight.Tickets.Count() + n;
        }

        public void DeletePlanes()
        {
           Delete(p=>p.ManufactureDate.AddYears(10)<DateTime.Now);
        }

        public IList<IGrouping<int, Flight>> GetFlights(int n)
        {
            return (IList<IGrouping<int, Flight>>)GetAll().Take(n).SelectMany(p => p.Flights.OrderByDescending(f=>f.FlightDate))
                .GroupBy(p=>p.PlaneId).ToList();
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
           return GetById(plane.PlaneId).Flights.
                SelectMany(f=>f.Tickets.Select(t=>t.Passenger)).ToList();
        }
    }
}
