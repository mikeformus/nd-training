using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace SvCustomerOrderService.Tests
{
    [TestFixture(CustomerType.Premium, 100.00)]
    [TestFixture(CustomerType.Basic)]
    public class SvCustomerOrderServiceTests
    {
        private CustomerType customerType;
        private double minOrder;

        public SvCustomerOrderServiceTests(CustomerType customerType, double minOrder)
        {
            this.customerType = customerType;
            this.minOrder = minOrder;
        }

        public SvCustomerOrderServiceTests(CustomerType customerType) : this(customerType, 0)
        {
        }

        [TestCase]
        public void TestMethod()
        {
            Assert.IsTrue((customerType == CustomerType.Basic && minOrder == 0 || customerType == CustomerType.Premium && minOrder > 0));
        }
    }

}