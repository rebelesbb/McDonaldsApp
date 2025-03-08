using McApp.domain;
using McApp.repositoy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McApp.service
{   
    public class McService
    {
        private readonly LocationsRepository locationsRepository;
        private readonly EmployeesRepository employeesRepository;

        public McService(LocationsRepository locationsRepository, EmployeesRepository employeesRepository)
        {
            this.locationsRepository = locationsRepository;
            this.employeesRepository = employeesRepository;
        }


        public void LoadAllLocations()
        {
            locationsRepository.LoadAllLocations();
        }


        public void LoadAllEmployees()
        {
            employeesRepository.LoadAllEmployees();
        }


        public void AddEmployee(string lastname, string firstname, int locationId, string phoneNumber,
            string position, int salary, DateTime hireDate)
        {

            Employee employee = new(firstname, lastname, locationId, phoneNumber, position, salary, hireDate);
            employeesRepository.Save(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            employeesRepository.Delete(employeeId);
        }

        public void UpdateEmployee(int employeeId, string lastname, string firstname, int locationId, string phoneNumber,
            string position, int salary, DateTime hireDate)
        {

            Employee employee = new(firstname, lastname, locationId, phoneNumber, position, salary, hireDate)
            {
                Id = employeeId
            };
            employeesRepository.Update(employee);
        }

    }
}
