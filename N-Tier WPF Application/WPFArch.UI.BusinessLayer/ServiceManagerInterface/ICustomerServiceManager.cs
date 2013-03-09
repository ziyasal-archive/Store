using System;
using WPFArch.UI.BusinessLayer.CustomerServiceReference;

namespace WPFArch.UI.BusinessLayer.ServiceManagerInterface
{
    public interface ICustomerServiceManager
    {
        void AddCustomer(string firstName, string lastName);
        void UpdateCustomer(CustomerDto customerDto);
        void DeleteCustomer(int customerId);
        void GetCustomers(Action<GetCustomersResponse,Exception> callback);

   
    }
}