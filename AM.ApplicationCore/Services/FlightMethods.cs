﻿using System;
using System.Collections;
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

        // QUESTION 16 ;
        public Action<Domain.Plane> FlightDetailsDel;
        public Func<string, float> DurationAverageDel;

        public FlightMethods() {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            FlightDetailsDel = p =>
            {
                var query = from flight in Flights
                            where flight.Plane == p
                            select flight;
                foreach (var item in query)
                {
                    Console.WriteLine(item.FlightDate + item.Destination);
                }
            };
            DurationAverageDel = d => {
                var query = from flight in Flights
                            where flight.Destination == d
                            select flight.EstimatedDuration;
                return query.Average();            
            };

        
        }
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
            //var query=from f in Flights
            //          where f.Destination == destination
            //          select f.FlightDate;
            //return query.ToList();

            // QUESTION 19 //
            var lambadaquery = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate);
            return lambadaquery.ToList();
        }

        public float DurationAverage(string destination)
        {
            //var query = from flight in Flights
            //            where flight.Destination == destination
            //            select flight.EstimatedDuration;
            //return query.Average();

            // QUESTION 19

            var lambdaquery=Flights
                .Where (f => f.Destination == destination)
                .Select(f => f.EstimatedDuration);
            return lambdaquery.Average();
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

        
        public void ShowFlightDetails(Domain.Plane plane)
        {
            //    var query = from flight in Flights
            //                where flight.Plane == plane
            //                select flight;
            //    foreach (var item in query)
            //    {
            //        Console.WriteLine(item.FlightDate + item.Destination);
            //    }
            // QUESTION 19
            var lambdaquery = Flights
                   .Where(f => f.Plane == plane)
                   .Select(f => f); //optional
            foreach (var item in lambdaquery)
            {
                Console.WriteLine(item.FlightDate + item.Destination);
            }
        }

        public IList<Flight> OrderdDurationFlights()
        {
            //var query = from flight in Flights
            //            orderby flight.EstimatedDuration descending
            //            select flight;
            //return query.ToList();

            var lmabdaquerry = Flights.OrderByDescending(f => f.EstimatedDuration);
            return lmabdaquerry.ToList();

        }

        


        public int ProgrammedFlightNumber(DateTime startDate)
        {
            // Methode 1 
            //var query = from flight in Flights
            //            where DateTime.Compare(flight.FlightDate,startDate)>0
            //            && (flight.FlightDate-startDate).TotalDays<7
            //            select flight;
            //return query.Count();
            //Methode 2
            //var query = from flight in Flights
            //            where flight.FlightDate >= startDate
            //            && flight.FlightDate < startDate.AddDays(7)
            //            select flight;
            //return query.Count();

            // QUESTION 19 
            var lambdaquery = Flights
                .Where(f => f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7));
            return lambdaquery.Count();

        }

        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from p in flight.ListPassengers.OfType<Traveller>()
            //            orderby p.BirthDate ascending
            //            select p;
            //return query.Take(3).ToList();
            var lambdaquery = flight.ListPassengers.OfType<Traveller>()
                .OrderBy(p => p.BirthDate);
            return lambdaquery.Take(3).ToList();
        }

        public void DestinationGroupFlights()
        {
            //var query = from flight in Flights
            //            group flight by flight.Destination;
            //foreach (var g in query) {
            //    Console.WriteLine("Destination"+g.Key);
            //    foreach(var f in g)
            // Console.WriteLine("Décolage:" + f.FlightDate);
            //}
            var lambdaquery = Flights.GroupBy(f => f.Destination);
                foreach (var g in lambdaquery)
            {
                Console.WriteLine("Destination" + g.Key);
                foreach (var f in g)
                    Console.WriteLine("Décolage:" + f.FlightDate);
            }
        }
        }
}