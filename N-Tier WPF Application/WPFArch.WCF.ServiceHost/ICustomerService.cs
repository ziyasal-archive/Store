using System.ServiceModel;
using WPFArch.WCF.DtoLibrary.Request.Customer;
using WPFArch.WCF.DtoLibrary.Response.Customer;

namespace WPFArch.WCF.ServiceHost
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        GetCustomersResponse GetCustomers();

        [OperationContract]
        AddCustomerResponse AddCustomer(AddCustomerRequest request);

        [OperationContract(IsOneWay = true)]
        void UpdateCustomer(UpdateCustomerRequest request);

        [OperationContract(IsOneWay = true)]
        void DeleteCustomer(DeleteCustomerRequest request);
    }
}
