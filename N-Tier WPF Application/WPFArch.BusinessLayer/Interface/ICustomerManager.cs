using System.Collections.Generic;
using WPFArch.WCF.DtoLibrary;
using WPFArch.WCF.DtoLibrary.Request.Customer;
using WPFArch.WCF.DtoLibrary.Request.Order;

namespace WPFArch.BusinessLayer.Interface
{
    public interface ICustomerManager
    {
        List<CustomerDto> GetCustomers();
        int AddCustomer(AddCustomerRequest request);
        void Update(UpdateCustomerRequest request);
        void Delete(DeleteCustomerRequest request);
        List<OrderDto> GetOrders(GetOrderByCustomerReguest reguest);
        int AddOrderToCustomer(AddOrderRequest request);
    }
}