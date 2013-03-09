using WPFArch.Data.CodeFirst.Models;
using WPFArch.WCF.DtoLibrary;

namespace WPFArch.BusinessLayer.Mapper
{

    public static class Mapper
    {
        public static CustomerDto ToCustomerDto(this Customer customer)
        {
            return new CustomerDto
                       {
                           CustomerId = customer.CustomerId,
                           FirstName = customer.FirstName,
                           LastName = customer.LastName
                       };
        }

        public static Customer ToCustomer(this CustomerDto customerDto)
        {
            return new Customer
            {
                CustomerId = customerDto.CustomerId,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName
            };
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
                       {
                           Description = order.Description,
                           OrderId = order.OrderId,
                           Quantity = order.Quantity
                       };
        }

        public static Order ToOrder(this OrderDto orderDto)
        {
            return new Order
            {
                OrderId = orderDto.OrderId,
                Description = orderDto.Description,
                Quantity = orderDto.Quantity
            };
        }
    }
}