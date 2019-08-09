using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CustomerOrderService_O.Tests
{
    [TestFixture(CustomerType.Premium, 100.00)]
    [TestFixture(CustomerType.Basic)]
    public class CustomerOrderServiceTests
    {
        private CustomerType customerType;
        private double minOrder;

        public CustomerOrderServiceTests(CustomerType customerType, double minOrder)
        {
            this.customerType = customerType;
            this.minOrder = minOrder;
        }

        public CustomerOrderServiceTests(CustomerType customerType) : this(customerType, 10)
        {
            this.customerType = customerType;
        }

        [TestCase]
        public void TestMethod()
        {
            Assert.IsTrue((customerType == CustomerType.Basic && minOrder == 10 || customerType == CustomerType.Premium && minOrder > 0));
        }

        [TestCase]
        public void When_PremiumCustomer_Expect_10PercentDiscount()
        {
            //Arrange
            Customer premiumCustomer = new Customer
            {
                CustomerId = 1,
                CustomerName = "Alex",
                CustomerType = CustomerType.Premium
            };

            Order order = new Order
            {
                OrderId = 1,
                ProductId = 212,
                ProductQuantity = 1,
                Amount = 150
            };

            CustomerOrderService_O customerOrderService = new CustomerOrderService_O();

            //Act
            customerOrderService.ApplyDiscount(premiumCustomer, order);

            //Assert
            Assert.AreEqual(order.Amount, 135);
        }
    }
}
