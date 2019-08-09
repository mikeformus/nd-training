using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EmployeeService_O.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        public virtual Worker CreateEmployee()
        {
            return new Employee();
        }

        [TestCase]
        public void When_NameContainsIllegalChars_Expect_ContainsIllegalChars_ReturnsTrue()
        {
            Worker employee = CreateEmployee();
            employee.Name = "Da$ya";

            var result = employee.ContainsIllegalChars();

            Assert.IsTrue(result);
        }
    }

    public class ManagerTests : EmployeeTests
    {
        public override Worker CreateEmployee()
        {
            return new Manager();
        }
    }

    public class VicePresidentTests : EmployeeTests
    {
        public override Worker CreateEmployee()
        {
            return new DeliveryManager();
        }
    }

    [TestFixture]
    public class EmployeeTestsTask2
    {
        [TestCase(60, Author = "Oleksandr")]
        [TestCase(80, Author = "Oleksandr")]
        [TestCase(90, Author = "Oleksandr")]
        [Order(2)]
        public void When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizenAsTrue(int age)
        {
            EmployeeTask2 emp = new EmployeeTask2();
            emp.Age = age;

            bool result = emp.IsSeniorCitizen();

            Assert.That(result == true);
        }

        [TestCase(29, ExpectedResult = false, Author = "Oleksandr", TestName = "Age => 60. Negative case. (29)")]
        [TestCase(0, ExpectedResult = false, Author = "Oleksandr")]
        [TestCase(60, ExpectedResult = true, Author = "Oleksandr")]
        [TestCase(80, ExpectedResult = true, Author = "Oleksandr", TestName = "Age => 60. Positive case. (80)")]
        [TestCase(90, ExpectedResult = true, Author = "Oleksandr")]
        [TestCase(-15, ExpectedResult = true, Author = "Oleksandr", Ignore = "Not comleted.")]
        [Order(1)]
        public bool When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizenAsResult(int age)
        {
            EmployeeTask2 emp = new EmployeeTask2();
            emp.Age = age;

            bool result = emp.IsSeniorCitizen();

            return result;
        }
    }

    [TestFixture]
    public class EmployeeTestsTask3
    {
        [TestCase(new int[] { 2, 4, 6 })]
        [Order(1)]
        public void When_AllNumberAreEven_Expects_AreAllNumbersEvenAsTrue(int[] numbers)
        {
            Number number = new Number();

            bool result = number.AreAllNumbersEven(numbers);

            Assert.That(result, Is.EqualTo(true));
        }

        [TestCaseSource(typeof(StringArrayTestDataSource))]
        [Order(2)]
        public void When_StringArrayAreEvenNumbers_Expects_IsStringArrayOfEvenNumbersAsTrue(string[] numbers)
        {
            Number number = new Number();

            bool result = number.IsStringArrayOfEvenNumbers(numbers);

            Assert.That(result == true);
        }

        [TestCase]
        public void When_EmployeesAreAdded_Expects_AreInAscendingOrderAsTrue()
        {
            List<EmployeeTask2> employees = new List<EmployeeTask2>();
            employees.Add(new EmployeeTask2 { Age = 32, Name = "Alex" });
            employees.Add(new EmployeeTask2 { Age = 49, Name = "Stephen" });
            employees.Add(new EmployeeTask2 { Age = 57, Name = "Xander" });

            Assert.That(employees, Is.Ordered.Ascending.By("Name").Then.Ascending.By("Age"));
        }

        [TestCase(9)]
        [TestCase(25)]
        public void When_EmployeesAreAdded_Expects_AreAdults(int age)
        {
            EmployeeTask2 emp = new EmployeeTask2();
            emp.Age = age;

            Assert.That(emp.Age, Is.GreaterThan(18).And.LessThan(99));
        }
    }
}