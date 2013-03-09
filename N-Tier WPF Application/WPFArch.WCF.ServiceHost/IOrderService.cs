using System.ServiceModel;
using WPFArch.WCF.DtoLibrary.Request.Order;
using WPFArch.WCF.DtoLibrary.Response.Order;

namespace WPFArch.WCF.ServiceHost
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        GetOrderByCustomerResponse GetOrderByCustomer(GetOrderByCustomerReguest reguest);

        [OperationContract]
        AddOrderResponse AddOrder(AddOrderRequest request);

        [OperationContract(IsOneWay = true)]
        void UpdateOrder(UpdateOrderRequest request);

        [OperationContract(IsOneWay = true)]
        void DeleteOrder(DeleteOrderRequest request);

        [OperationContract]
        GetOrderResponse GetOrder(GetOrderRequest request);
    }
}
