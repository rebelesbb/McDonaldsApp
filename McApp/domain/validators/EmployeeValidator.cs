using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McApp.domain.validators
{
    public class EmployeeValidator
    {
        public void ValidateEmployee(Employee employee)
        {
            string errors = "";
            string missingAttributes = "";

            if (employee.Firstname.Length == 0)
                missingAttributes += "*prenume\n";

            if (employee.Lastname.Length == 0)
                missingAttributes += "*nume\n";

            if (employee.PhoneNumber.Length == 0)
                missingAttributes += "*telefon\n";
            else if (employee.PhoneNumber.Length != 10 || !employee.PhoneNumber.StartsWith("07"))
                errors += "Numar de telefon invalid\n";

            if (employee.Salary < 2000)
                errors += "Salariu invalid\n";

            if (employee.HireDate.Date > DateTime.Today.Date)
                errors += "Data invalida\n";

            if (missingAttributes.Length > 0)
                errors += "Urmatoarele campuri sunt obligatorii:\n" + missingAttributes;

            if (errors.Length > 0)
                throw new ValidationException(errors);
        }
    }
}
