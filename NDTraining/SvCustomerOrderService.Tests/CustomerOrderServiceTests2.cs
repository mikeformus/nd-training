using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvCustomerOrderService.Tests
{
    [TestFixture(CustomerType.Premium, 100.00, TypeArgs = new Type[] { typeof(CustomerType), typeof(double) })]
    public class CustomerOrderServiceTests<T1, T2>
    {
        private T1 customerType;
        private T2 minOrder;

        public CustomerOrderServiceTests(T1 customerType, T2 minOrder)
        {
            this.customerType = customerType;
            this.minOrder = minOrder;
        }

        [TestCase]
        public void TestMethod()
        {
            Assert.That(customerType, Is.TypeOf<CustomerType>());
            Assert.That(minOrder, Is.TypeOf<double>());
        }
    }
}
