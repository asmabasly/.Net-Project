using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public bool CheckProfile(string firstName, string lastName) =>
            FirstName == firstName && LastName == lastName;

        public bool CheckProfile(string firstName, string lastName, string email) =>
            FirstName == firstName && LastName == lastName && Email == email;

        public virtual void PassengerType() => Console.WriteLine("I am a passenger");

        public override string ToString() => $"{FirstName} {LastName} ({Email})";
    }
}

