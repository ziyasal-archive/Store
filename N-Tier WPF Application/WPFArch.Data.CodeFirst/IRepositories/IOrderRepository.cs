using System.Collections.Generic;
using WPFArch.Data.CodeFirst.Infrastructure;
using WPFArch.Data.CodeFirst.Models;

namespace WPFArch.Data.CodeFirst.IRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Customer FindByOrder(int orderId);
        int InsertAndReturnID(Order entity);
        List<Order> FindByCustomer(int customerId);
    }
}