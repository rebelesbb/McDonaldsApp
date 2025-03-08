using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McApp.domain
{
    public class Employee: Entity<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int LocationId { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public DateTime HireDate { get; set; }


        public Employee(string firstname, string lastname, int locationId, string phoneNumber, string position, int salary, DateTime hireDate)
        {
            Firstname = firstname;
            Lastname = lastname;
            LocationId = locationId;
            PhoneNumber = phoneNumber;
            Position = position;
            Salary = salary;
            HireDate = hireDate;
        }
    }
}
