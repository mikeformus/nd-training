using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvEmployeeService
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsSeniorCitizen()
        {
            if (Age >= 60)
            {
                return true;
            }
            return false;
        }

        public bool ContainsIllegalChars()
        {
            throw new NotImplementedException();
        }
    }

    public class Manager : Employee { }

    public class DeliveryManager : Employee { }
}
