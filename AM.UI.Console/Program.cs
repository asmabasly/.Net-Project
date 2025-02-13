using System;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.ApplicationCore.Interface;

class Program
{
    static void Main()
    {
        //Plane plane1 = new Plane();
        //plane1.Capacity = 100;
        //plane1.ManufactureDate = new DateTime(2024, 05, 23);
        //plane1.PlaneType = PlaneType.Airbus;
        //plane1.PlaneId = 1;
        //Console.WriteLine(plane1.ToString());
        //Plane plane2 = new Plane(PlaneType.Airbus, 200, DateTime.Now);
        //Console.WriteLine(plane2.ToString());

        Plane plane3 = new Plane
        {
            ManufactureDate = DateTime.Now,
            Capacity = 300,
            PlaneId = 3,
            PlaneType = PlaneType.Boeing,
        };
        Console.WriteLine(plane3.ToString());
        Plane plane4 = new Plane { };
        Console.WriteLine(plane4.ToString());
        Passenger passenger = new Passenger { FirstName = "Asma", LastName = "Basly", Email = "asma.Basly@esprit.tn" };
        Console.WriteLine(passenger.ToString());
        Console.WriteLine(passenger.CheckProfile("Asma", "Basly"));
        Console.WriteLine(passenger.CheckProfile("Asma", "Basly", "asma.Basly@esprit.tn"));
        Staff staff1 = new Staff { FirstName = "StaffFirstName", LastName = "StaffLastName" };
        Traveller traveller1 = new Traveller { Nationality = "Tunisian", FirstName = "TravellerFirstName" };
        passenger.PassengerType();
        staff1.PassengerType();
        traveller1.PassengerType();

        /// ATELIZE 2 /////////////
        FlightMethods flightMethods = new FlightMethods {
            Flights = Testdata.listFlights
        };
        foreach(var item in flightMethods.GetFlightDates("Paris"))
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("----------------- QUESTION 8 -----------------");
        flightMethods.GetFlights("Destination", "Paris");

        //Console.WriteLine("QUESTION 10 //");
        //flightMethods.ShowFlightDetails(Testdata.Airbusplane);

        Console.WriteLine("----------------- QUESTION 11 -----------------");
        //Console.WriteLine(flightMethods.ProgrammedFlightNumber(new DateTime(2022, 01, 01, 10, 10, 10)));
        
        Console.WriteLine("----------------- QUESTION 12 -----------------");
        Console.WriteLine(flightMethods.DurationAverage("Madrid"));

        Console.WriteLine(" ----------------- QUESTION 13 -----------------");
        foreach (var item in flightMethods.OrderdDurationFlights())
        { Console.WriteLine(item); }


        Console.WriteLine("QUESTION 14 //");
        foreach (var item in flightMethods.SeniorTravellers(Testdata.flight1))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(" ----------------- QUESTION 15 -----------------");
        flightMethods.DestinationGroupFlights();

        Console.WriteLine("------------------ QUESTION 16 sans delegate -----------------");

        flightMethods.ShowFlightDetails(Testdata.Airbusplane);
        Console.WriteLine(" ----------------- QUESTION 16 avec delegate -----------------");

        flightMethods.FlightDetailsDel(Testdata.Airbusplane);

    }
}

