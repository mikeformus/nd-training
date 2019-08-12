using System;
using NUnit.Framework;

namespace SvEmployeeService.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        public virtual Employee CreateEmployee()
        {
            return new Employee();
        }

        [TestCase(29, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(60, ExpectedResult = true)]
        [TestCase(80, ExpectedResult = true)]
        [TestCase(90, ExpectedResult = true)]
        public bool When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizeAsTrue(int age)
        {
            Employee emp = new Employee();
            emp.Age = age;

            bool result = emp.IsSeniorCitizen();

            return result;
        }
    }

    public class ManagerTests : EmployeeTests
    {
        public override Employee CreateEmployee()
        {
            return new Manager();
        }
    }

    public class VicePresidentTests : EmployeeTests
    {
        public override Employee CreateEmployee()
        {
            return new DeliveryManager();
        }
    }
}