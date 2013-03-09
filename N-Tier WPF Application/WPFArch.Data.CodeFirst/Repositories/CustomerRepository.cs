using WPFArch.Data.CodeFirst.IRepositories;
using WPFArch.Data.CodeFirst.Infrastructure;
using WPFArch.Data.CodeFirst.Models;

namespace WPFArch.Data.CodeFirst.Repositories
{
    public class CustomerRepository : EntityRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public override void Update(Customer entity)
        {
            Customer customer = Find(entity.CustomerId);
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;

            //TODO Generic Update !!!!
            //EntityState entityState = DataContext.Entry(entity).State;

            //if(entityState==EntityState.Detached)
            //{
            //    DataContext.Orders.Attach(entity);   
            //}
        }
    }
}