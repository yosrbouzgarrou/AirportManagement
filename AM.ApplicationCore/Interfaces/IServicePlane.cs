using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        // signature des méthodes sauf CRUD ( CRUD : IService)

        IList<Passenger> GetPassengers(Plane plane);
        IList<IGrouping<int, Flight>> GetFlights(int n);
        bool AvailablePlane(Flight flight,int n);
        void DeletePlanes();

    }
}
