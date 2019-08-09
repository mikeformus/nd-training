using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService_O
{
    public abstract class Worker
    {
        public string Name { get; set; }

        public bool ContainsIllegalChars()
        {
            if (this.Name.Contains("$"))
            {
                return true;
            }
            return false;
        }
    }

    public class Employee : Worker { }

    public class Manager : Worker { }

    public class DeliveryManager : Worker { }

    public class EmployeeTask2
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
    }

    public class Number
    {
        public bool AreAllNumbersEven(int[] numbers)
        {
            bool result = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool IsStringArrayOfEvenNumbers(string[] numbers)
        {
            bool result = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (Int32.Parse(numbers[i]) % 2 == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }

    public class StringArrayTestDataSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new string[] { "2", "4", "6" };
            yield return new string[] { "3", "4", "5" };
            yield return new string[] { "6", "8", "10" };
        }
    }
}
