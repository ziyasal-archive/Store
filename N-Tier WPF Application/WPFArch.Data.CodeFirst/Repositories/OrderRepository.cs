using System.Collections.Generic;
using System.Linq;
using WPFArch.Data.CodeFirst.IRepositories;
using WPFArch.Data.CodeFirst.Infrastructure;
using WPFArch.Data.CodeFirst.Models;

namespace WPFArch.Data.CodeFirst.Repositories
{
    public class OrderRepository : EntityRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public override void Update(Order entity)
        {
            Order order = Find(entity.OrderId);
            order.Description = entity.Description;
            order.Quantity = entity.Quantity;

            //TODO Generic Update !!!!
            //EntityState entityState = DataContext.Entry(entity).State;

            //if(entityState==EntityState.Detached)
            //{
            //    DataContext.Orders.Attach(entity);   
            //}
        }

        public Customer FindByOrder(int orderId)
        {
            Order firstOrDefault = DataContext.Orders.FirstOrDefault(order => order.OrderId == orderId);
            return firstOrDefault != null ? firstOrDefault.Customer : null;
        }

        public int InsertAndReturnID(Order entity)
        {
            base.Insert(entity);

            return entity.OrderId;
        }

        public List<Order> FindByCustomer(int customerId)
        {
            return DataContext.Customers.First(i => i.CustomerId == customerId).Orders.ToList();
        }
    }
}