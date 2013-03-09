using System.ServiceModel.Activation;
using WPFArch.BusinessLayer.Interface;
using WPFArch.WCF.DtoLibrary.Request.Order;
using WPFArch.WCF.DtoLibrary.Response.Order;
using WPFArch.WCF.ServiceHost.Elmah;

namespace WPFArch.WCF.ServiceHost
{
    [ServiceErrorBehavior(typeof(ElmahErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class OrderService : IOrderService
    {
        private readonly ICustomerManager _customerManager;
        private readonly IOrderManager _orderManager;

        public OrderService(ICustomerManager customerManager, IOrderManager orderManager)
        {
            _customerManager = customerManager;
            _orderManager = orderManager;
        }

        public GetOrderByCustomerResponse GetOrderByCustomer(GetOrderByCustomerReguest reguest)
        {
            return new GetOrderByCustomerResponse
                       {
                           Orders = _customerManager.GetOrders(reguest)
                       };
        }

        public AddOrderResponse AddOrder(AddOrderRequest request)
        {
            return new AddOrderResponse
                       {
                           OrderID = _customerManager.AddOrderToCustomer(request)
                       };
        }

        public void UpdateOrder(UpdateOrderRequest request)
        {
            _orderManager.Update(request);
        }

        public void DeleteOrder(DeleteOrderRequest request)
        {
            _orderManager.Delete(request);
        }

        public GetOrderResponse GetOrder(GetOrderRequest request)
        {
            return new GetOrderResponse()
                       {
                           OrderDto = _orderManager.GetOrder(request)
                       };
        }
    }
}
