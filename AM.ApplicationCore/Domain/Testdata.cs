﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Testdata
    {
        public static Plane BoingPlane = new Plane { PlaneType = PlaneType.Boeing, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };
        public static Plane Airbusplane = new Plane { PlaneType = PlaneType.Airbus, Capacity = 250, ManufactureDate = new DateTime(2020, 11, 11) };
        // Staffs
        public static Staff captain = new Staff { FirstName = "captain", LastName = "captain", EmployementDate = new DateTime(1999, 01, 01), Salary = 99999 };
        public static Staff hostess1 = new Staff { FirstName = "hostess1", LastName = "hostess1", EmployementDate = new DateTime(2020, 01, 01), Salary = 999 };
        public static Staff hostess2 = new Staff { FirstName = "hostess2", LastName = "hostess2",EmployementDate = new DateTime(2020, 01, 01), Salary = 999 };
        // Travellers
        public static Traveller traveller1 = new Traveller { FirstName = "traveller1", LastName = "traveller1", HealthInformation = "no troubles", Nationality = "American" };
        public static Traveller traveller2 = new Traveller { FirstName = "traveller2", LastName = "traveller2",  HealthInformation = "Some troubles", Nationality = "French" };
        public static Traveller traveller3 = new Traveller { FirstName = "traveller3", LastName = "traveller3",HealthInformation = "no troubles", Nationality = "Tunisian" };
        public static Traveller traveller4 = new Traveller { FirstName = "traveller4", LastName = "traveller4", HealthInformation = "Some troubles", Nationality = "American" };
        public static Traveller traveller5 = new Traveller { FirstName = "traveller5", LastName = "traveller5", HealthInformation = "Some troubles", Nationality = "Spanish" };
        // Flights
        // Affect all passengers to flight1
        public static Flight flight1 = new Flight
        {
            FlightDate = new DateTime(2022, 01, 01, 15, 10, 10),
            Destination = "Paris",
            EffectiveArrival = new DateTime(2022, 01, 01, 17, 10, 10),
            EstimatedDuration = 110,
            ListPassengers = new List<Passenger> { captain, hostess1, hostess2, traveller1, traveller2, traveller3, traveller4, traveller5 }
       ,
            Plane = Airbusplane
        };
        public static Flight flight3 = new Flight { FlightDate = new DateTime(2022, 03, 01, 5, 10, 10), Destination = "Paris", Departure="Tunis", EffectiveArrival = new DateTime(2022, 03, 01, 6, 40, 10), EstimatedDuration = 100, Plane = BoingPlane };
        public static Flight flight4 = new Flight { FlightDate = new DateTime(2022, 04, 01, 6, 10, 10), Destination = "Madrid", EffectiveArrival = new DateTime(2022, 04, 01, 8, 10, 10), EstimatedDuration = 130, Plane = BoingPlane };
        public static Flight flight5 = new Flight { FlightDate = new DateTime(2022, 05, 01, 17, 10, 10), Destination = "Madrid", EffectiveArrival = new DateTime(2022, 05, 01, 18, 50, 10), EstimatedDuration = 105, Plane = BoingPlane };
        public static Flight flight6 = new Flight { FlightDate = new DateTime(2022, 06, 01, 20, 10, 10), Destination = "Lisbonne", EffectiveArrival = new DateTime(2022, 06, 01, 22, 30, 10), EstimatedDuration = 200, Plane = Airbusplane };

        //test list
        public static List<Flight> listFlights = new List<Flight> { flight1,  flight3, flight4, flight5, flight6 };
    }
}

