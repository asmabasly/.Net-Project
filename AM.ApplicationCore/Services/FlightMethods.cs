using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethode
    {
        public List<Flight> Flights { get; set; } = new List<Flight> { };


        public IList<DateTime> GetFlightDates(string destination)
        {
            IList<DateTime> dates = new List<DateTime> { };
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination.Equals(destination))
            //    {
            //        dates.Add
            //    }
            //}
            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination.Equals(destination))
            //        dates.Add(flight.FlightDate);
            //}



            //return dates;
            // QUESTION 9
            var query=from f in Flights
                      where f.Destination == destination
                      select f.FlightDate;
            return query.ToList();
        }

        public float DurationAverage(string destination)
        {
            var query = from flight in Flights
                        where flight.Destination == destination
                        select flight.EstimatedDuration;
            return query.Average();
        }
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                            Console.WriteLine(flight);


                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {

                        if (flight.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;
                case "EstimatedValue":
                    foreach (var flight in Flights)
                    {

                        if (flight.EstimatedDuration == float.Parse(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {

                        if (flight.Departure.Equals(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {

                        if (flight.EffectiveArrival==DateTime.Parse(filterValue))
                            Console.WriteLine(flight);
                    }
                    break;
            }
        }

        
        //public void ShowFlightDetails(Plane plane)
        //{
        //    var query = from flight in Flights
        //                where flight.Plane == plane
        //                select flight;
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine(item.FlightDate + item.Destination);
        //    }
        //}
        
        public IList<Flight> OrderdDurationFlights()
        {
            var query = from flight in Flights
                        orderby flight.EstimatedDuration descending
                        select flight;
            return query.ToList();

        }

        public void ShowFlightDetails(Domain.Plane plane)
        {
        //    var query = from flight in Flights
        //                where flight.Plane == plane
        //                select flight;
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine(item.FlightDate + item.Destination);
        //    }
        }

        float IFlightMethode.ProgrammedFlightNumber(DateTime startDate)
        {
            // Methode 1 
            //var query = from flight in Flights
            //            where DateTime.Compare(flight.FlightDate,startDate)>0
            //            && (flight.FlightDate-startDate).TotalDays<7
            //            select flight;
            //return query.Count();
            //Methode 2
            var query = from flight in Flights
                        where flight.FlightDate >= startDate
                        && flight.FlightDate < startDate.AddDays(7)
                        select flight;
            return query.Count();

        }

        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            var query = from p in flight.ListPassengers.OfType<Traveller>()
                        orderby p.BirthDate ascending
                        select p;
            return query.Take(3).ToList();
        }

        public void DestinationGroupFlights()
        {
            var query = from flight in Flights
                        group flight by flight.Destination;
            foreach (var g in query) {
                Console.WriteLine("Destination"+g.Key);
                foreach(var f in g)
             Console.WriteLine("Décolage:" + f.FlightDate);
            }
        }
    }
}