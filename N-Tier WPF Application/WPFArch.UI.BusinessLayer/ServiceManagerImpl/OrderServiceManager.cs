using System;
using System.Reflection;
using WPFArch.UI.BusinessLayer.Common;
using WPFArch.UI.BusinessLayer.OrderServiceReference;
using WPFArch.UI.BusinessLayer.ServiceManagerInterface;

namespace WPFArch.UI.BusinessLayer.ServiceManagerImpl
{
    public class OrderServiceManager : IOrderServiceManager
    {


        public void AddOrder(int customerId, OrderDto orderDto)
        {
            OrderServiceClient orderServiceClient = new OrderServiceClient();
            try
            {
                orderServiceClient.AddOrder(new AddOrderRequest
                                                    {
                                                        CustomerID = customerId,
                                                        OrderDto = orderDto
                                                    });
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured while in type :{0} , method :{1} ", "OrderServiceManager", MethodBase.GetCurrentMethod().Name);
                CommonLogManager.Log.Error(message, exception);
                throw;
            }
            finally
            {
                orderServiceClient.Close();
            }
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            OrderServiceClient orderServiceClient = new OrderServiceClient();
            try
            {
                orderServiceClient.UpdateOrder(new UpdateOrderRequest
                                                   {
                                                       OrderDto = orderDto
                                                   });
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured while in type :{0} , method :{1} ", "OrderServiceManager", MethodBase.GetCurrentMethod().Name);
                CommonLogManager.Log.Error(message, exception);
                throw;
            }
            finally
            {
                orderServiceClient.Close();
            }
        }

        public void DeleteOrder(int orderId)
        {
            OrderServiceClient orderServiceClient = new OrderServiceClient();
            try
            {
                orderServiceClient.DeleteOrder(new DeleteOrderRequest
                                                   {
                                                       OrderID = orderId
                                                   });
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured while in type :{0} , method :{1} ", "OrderServiceManager", MethodBase.GetCurrentMethod().Name);
                CommonLogManager.Log.Error(message, exception);
                throw;
            }
            finally
            {
                orderServiceClient.Close();
            }
        }

        public void GetOrders(int customerID,Action<GetOrderByCustomerResponse,Exception> callback)
        {
            OrderServiceClient orderServiceClient = new OrderServiceClient();
            try
            {
                if (callback != null) orderServiceClient.GetOrderByCustomerCompleted += (s,e)=>callback(e.Result,e.Error);
                orderServiceClient.GetOrderByCustomerAsync(new GetOrderByCustomerReguest
                {
                    CustomerID = customerID
                });
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured while in type :{0} , method :{1} ", "OrderServiceManager", MethodBase.GetCurrentMethod().Name);
                CommonLogManager.Log.Error(message, exception);
                throw;
            }
            finally
            {
                orderServiceClient.Close();
            }
        }
    }
}