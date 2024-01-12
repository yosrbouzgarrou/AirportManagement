// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

Console.WriteLine("Hello, World!");
//initialisation via prop
Plane  plane = new Plane();
plane.Capacity = 20;
plane.PlaneId = 1;
plane.ManufactureDate= DateTime.Now;
plane.PlaneType = PlaneType.Boing;
Console.WriteLine("Plane 1 = "+plane.ToString());
// initialisation via constructeur
Plane plane2=new Plane(20,1,DateTime.Now,PlaneType.Boing);
Console.WriteLine("Plane 2 = "+plane2.ToString());
//initialiseur d'objet
Plane plane3 =  new Plane { PlaneId=12,PlaneType=PlaneType.Airbus,Capacity=150,Flights=TestData.listFlights};

Console.WriteLine("Plane 3 ="+plane3.ToString());

Console.WriteLine("**********************GetMyType*****************************");

Passenger passenger = new Passenger()
{
    BirthDate = new DateTime(1995, 12, 23),
    EmailAddress = "mohamed.lachtar@esprit.tn",
    FullName = new FullName { 
    FirstName = "Mohamed",
    LastName = "Lachtar"
    },
    TelNumber = 20123456,
    PassportNumber = "0124f5f",
};  
Traveller traveller = new Traveller()
{
    BirthDate = new DateTime(2000, 06, 16),
    EmailAddress = "islem.samaali@esprit.tn",
    FullName=new FullName
    {
        FirstName = "Islem",
        LastName = "Samaali"
    },
    TelNumber = 99123456,
    PassportNumber = "012444rf5f",
    Nationality ="Tunisian",
    HealthInformation="fine"
};
Staff staff = new Staff()
{
    BirthDate = new DateTime(1999, 10, 24),
    EmailAddress = "Souhail.Krisaane@esprit.tn",
    FullName=new FullName
    {
        FirstName = "Souhail",
        LastName = "Krisaane"
    },
    TelNumber = 50123456,
    PassportNumber = "012444rf5f",
    Salary = 10000,
    Function = "Captain",
    EmployementDate = new DateTime(2022, 09, 01)
};



Flight f1 = new Flight()
{
    FlightId = 1,
    Destination = "paris",
    Departure = "tunis",
    FlightDate = new DateTime(2022, 10, 23),
    EstimatedDuration = 2,
    AirlineLogo = "logo",
    EffectiveArrival = new DateTime(2022, 10, 23),
    PlaneId = 1,
    Plane = plane2,
    
};

Flight f2 = new Flight()
{
    FlightId = 2,
    Destination = "new york",
    Departure = "tunis",
    FlightDate = new DateTime(2022, 10, 22),
    EstimatedDuration = 2,
    AirlineLogo = "logooo",
    EffectiveArrival = new DateTime(2022, 10, 23),
    PlaneId = 1,
    Plane = plane2

};



Console.WriteLine(passenger.PassengerType());
Console.WriteLine(staff.PassengerType());
Console.WriteLine(traveller.PassengerType());



Console.WriteLine("*****************************PARTIE 2 *****************************");

/*ServiceFlight serviceFlight = new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;*/


//l = serviceFlight.OrderedDurationFlights();
//l = serviceFlight.GetFlightDates("Paris");
//int a= serviceFlight.ProgrammedFlightNumber(2022, 05, 01, 18, 50, 10);
//double d = serviceFlight.DurationAverage("Paris");
//Console.WriteLine(d);
//serviceFlight.SeniorTravellers(TestData.listFlights[0]).ForEach(Console.WriteLine);

//Console.WriteLine(serviceFlight.DestinationGroupedFlights());

//serviceFlight.ShowFlightDetails(plane3);
//serviceFlight.GetFlights("Destination", "Paris");



Console.WriteLine( "***************************Lazy loading****************************");


Flight filght = new Flight 
{ 
    //FlightId = 1, auto
    FlightDate = new DateTime(2022,10,10),
    Departure = "Tunis",
    Destination = "Paris",
    EffectiveArrival = new DateTime(2022,10,11),
    EstimatedDuration = 2,
    AirlineLogo = "plane.pnj",
    Plane = new Plane
    {
       Capacity=150,
       ManufactureDate= new DateTime(2020,12,12),
       PlaneType = PlaneType.Airbus
    }
};

AMContext mycontext = new AMContext();
mycontext.Flights.Add(filght); // ajout du flight dans dbset
mycontext.SaveChanges(); // synchronisation

foreach (Flight f in mycontext.Flights)
{
    Console.WriteLine(" \n \n Flight = "+f.ToString() +"\n"+"Plane = " +f.Plane.ToString());
}


Console.WriteLine("***************************Fin**************************");
Console.ReadKey();
