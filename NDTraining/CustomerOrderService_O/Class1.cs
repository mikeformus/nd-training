using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService_O
{
    public enum CustomerType
    {
        Basic,
        Premium,
        SpecialCustomer
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public CustomerType CustomerType { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Amount { get; set; }
    }

    public class CustomerOrderService_O
    {
        public void ApplyDiscount(Customer customer, Order order)
        {
            if (customer.CustomerType == CustomerType.Premium)
            {
                order.Amount = order.Amount - ((order.Amount * 10) / 100);
            }
            else if (customer.CustomerType == CustomerType.SpecialCustomer)
            {
                order.Amount = order.Amount - ((order.Amount * 20) / 100);
            }
        }
    }
}