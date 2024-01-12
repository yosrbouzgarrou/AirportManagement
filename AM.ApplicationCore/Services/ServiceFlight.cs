using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public  class ServiceFlight:Service<Flight>,IServiceFlight
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }



        #region TP2 LINQ
        public List<Flight> Flights => GetAll().ToList();// from DB
        public List<DateTime> GetFlightDates(string destination)
        {
            List < DateTime > listeDate = new List<DateTime> ();
            /*for (int i = 0; i < Flights.Count; i++)
            
                if(Flights[i].Destination == destination)
                    listeDate.Add(Flights[i].FlightDate);
                return listeDate;*/
            /*
            foreach (Flight f in Flights)
            
                if(f.Destination.Equals(destination))
                    listeDate.Add(f.FlightDate);
            return listeDate;
            */
            //linq
            /*
            
            var query = from x in Flights
                        where x.Destination == destination 
                        select x.FlightDate;
            return query.ToList();*/
            //lambda
            return Flights.Where(f => f.Destination == destination).
                Select(f=>f.FlightDate).ToList();
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //linq
            /* var query = from x in Flights
                         where DateTime.Compare(x.FlightDate, startDate) > 0 &&
                         (x.FlightDate-startDate).TotalDays < 7
                         select x;
             return query.Count();*/
            //lambda
            var result = Flights.Where(x => DateTime.Compare(x.FlightDate, startDate) > 0 &&
                         (x.FlightDate - startDate).TotalDays < 7);
            return result.Count();
        }
        public double DurationAverage(string destination)
        {
            /*
            var query = from x in Flights
            where x.Destination == destination 
            select x.EstimatedDuration;
            return query.Average();
            */
            //linq
            /*
            return (from x in Flights
            where x.Destination == destination 
            select x.EstimatedDuration).Average();*/
            //lambda
            return Flights.Where(f => f.Destination == destination).
                Select(f => f.EstimatedDuration).Average();
        }
        public List<Flight> OrderedDurationFlights()
        {
            //linq
            /*
            return (from x in Flights
                    orderby x.EstimatedDuration descending
                    select x).ToList();*/
            //lambda
            return Flights.OrderByDescending(f=>f.EstimatedDuration).ToList();
        }
        public List<Traveller> SeniorTravellers(Flight flight)
        {
            //linq
            /*
            var query = from x in flight.Passengers.OfType<Traveller>()
                        orderby x.BirthDate ascending 
                        select x;
            return query.Take(3).ToList();  */          //return query.Skip(3) si on veut ignorer les 3 permiers travellers
            //lambda
            return flight.Passengers.OfType<Traveller>().OrderBy(x => x.BirthDate).Take(3).ToList();
                }
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //linq
            /*
            var query = from x in Flights 
                        group x by x.Destination;
            */
            //lambda
            var query = Flights.GroupBy(x => x.Destination);
            foreach(var flight in query)
            {
                Console.WriteLine("Destination: " + flight.Key);
                foreach(var d in flight)
                {
                    Console.WriteLine("Décollage: " + d.FlightDate);
                }
            }
            return query;
            

        }
        public void ShowFlightDetails(Plane plane)
        {
            //linq
            /*
            // var query = from x in plane.Flights select x;
             var query = from x in plane.Flights 
                         select new { x.FlightDate, x.Destination };
            */
            //lambda
            var query = plane.Flights.Select(x => new { x.FlightDate, x.Destination });
            foreach (var flight in query.ToList())
            {
                Console.WriteLine("Date: " + flight.FlightDate +
                    " Destination: " + flight.Destination);
            }
            
            

        }
        #endregion
        #region TP1
        public void GetFlights(string filterType,string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if(f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate==DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                
                    
                    
            }
        }

        
        #endregion TP1
        #region TP2 delegate
        /*public Action<Plane> FlightDetailsDel;
        public Func<string,double> DurationAverageDel;
        public ServiceFlight()
        {
            /*FlightDetailsDel = ShowFlightDetails;
            DurationAverageDel = DurationAverage;*/


           /* FlightDetailsDel = p =>
            {
                var query = from f in Flights
                            where f.Plane == p
                            select new { f.Destination, f.FlightDate };
                foreach (var f in query)
                    Console.WriteLine("flights date " + f.FlightDate + "Destination" + f.Destination);
            };

            DurationAverageDel = dest =>
            {
                return (from f in Flights
                        where f.Destination.Equals(dest)
                        select f.EstimatedDuration).Average();
            };

        }*/
        #endregion
    }
}
