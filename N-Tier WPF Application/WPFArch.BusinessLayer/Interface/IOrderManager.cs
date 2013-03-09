using WPFArch.WCF.DtoLibrary;
using WPFArch.WCF.DtoLibrary.Request.Order;

namespace WPFArch.BusinessLayer.Interface
{
    public interface IOrderManager
    {
        void Update(UpdateOrderRequest request);
        void Delete(DeleteOrderRequest request);
        OrderDto GetOrder(GetOrderRequest request);
    }
}