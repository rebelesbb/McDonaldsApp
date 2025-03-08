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
        private LocationsRepository locationsRepository;
        private EmployeesRepository employeesRepository;

        public McService(LocationsRepository locationsRepository, EmployeesRepository employeesRepository)
        {
            this.locationsRepository = locationsRepository;
            this.employeesRepository = employeesRepository;
        }


        public void LoadAllLocations(DataSet dataSet)
        {
            locationsRepository.LoadAllLocations(dataSet);
        }


        public void LoadAllEmployees(DataSet dataSet)
        {
            employeesRepository.LoadAllEmployees(dataSet);
        }


        public void AddEmployee(DataSet dataSet, String lastname, String firstname, int locationId, String phoneNumber,
            String position, int salary, DateTime hireDate)
        {
            employeesRepository.Save(dataSet, lastname, firstname, locationId, phoneNumber,
                position, salary, hireDate);
        }

        public void DeleteEmployee(DataSet dataSet, int employeeId)
        {
            employeesRepository.Delete(dataSet, employeeId);
        }

        public void UpdateEmployee(DataSet dataSet, int employeeId, String lastname, String firstname, int locationId, String phoneNumber,
            String position, int salary, DateTime hireDate)
        {
            employeesRepository.Update(dataSet, employeeId, lastname, firstname, locationId, phoneNumber,
                position, salary, hireDate);
        }

    }
}
