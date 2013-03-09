using System;
using WPFArch.UI.BusinessLayer.OrderServiceReference;

namespace WPFArch.UI.BusinessLayer.ServiceManagerInterface
{
    public interface IOrderServiceManager
    {
        void AddOrder(int customerId, OrderDto orderDto);
        void UpdateOrder(OrderDto orderDto);
        void DeleteOrder(int orderId);
        void GetOrders(int customerID, Action<GetOrderByCustomerResponse, Exception> callback);
    }
}