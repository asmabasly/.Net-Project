using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interface
{
    public interface IFlightMethode
    {
        public IList<DateTime> GetFlightDates(string destinatin);
        public void GetFlights(string filterType, string flightValue);

        public void ShowFlightDetails(Plane plane);

        public float ProgrammedFlightNumber(DateTime startDate);

        public float DurationAverage(string destination);

        public IList<Flight> OrderdDurationFlights();
        public IList<Traveller> SeniorTravellers(Flight flight);
        public void DestinationGroupFlights();

    }
}
