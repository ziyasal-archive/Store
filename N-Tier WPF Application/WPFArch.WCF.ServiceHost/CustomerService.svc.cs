using System.ServiceModel.Activation;
using WPFArch.BusinessLayer.Interface;
using WPFArch.WCF.DtoLibrary.Request.Customer;
using WPFArch.WCF.DtoLibrary.Response.Customer;
using WPFArch.WCF.ServiceHost.Elmah;

namespace WPFArch.WCF.ServiceHost
{
    [ServiceErrorBehavior(typeof(ElmahErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerManager _customerManager;

        public CustomerService(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public GetCustomersResponse GetCustomers()
        {
            return new GetCustomersResponse
                       {
                           Customers = _customerManager.GetCustomers()
                       };
        }

        public AddCustomerResponse AddCustomer(AddCustomerRequest request)
        {
            return new AddCustomerResponse
                       {
                           CustomerID = _customerManager.AddCustomer(request)
                       };
        }

        public void UpdateCustomer(UpdateCustomerRequest request)
        {
            _customerManager.Update(request);
        }

        public void DeleteCustomer(DeleteCustomerRequest request)
        {
            _customerManager.Delete(request);
        }
    }
}