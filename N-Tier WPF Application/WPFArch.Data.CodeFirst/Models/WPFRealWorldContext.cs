using System.Data.Entity;
using WPFArch.Data.CodeFirst.Models.Mapping;

namespace WPFArch.Data.CodeFirst.Models
{
    public class WPFRealWorldContext : DbContext
    {
        static WPFRealWorldContext()
        {
            Database.SetInitializer<WPFRealWorldContext>(null);
        }

        public WPFRealWorldContext()
            : base("Name=WPFRealWorldContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
        }

        public class WPFRealWorldContextInitializer : DropCreateDatabaseIfModelChanges<WPFRealWorldContext>
        {
            protected override void Seed(WPFRealWorldContext context)
            {
                Customer customer = new Customer { FirstName = "Ziya", LastName = "SARIKAYA" };
                customer.Orders.Add(new Order
                {
                    Description = "Test Seed",
                    Quantity = 56
                });
                customer.Orders.Add(new Order
                {
                    Description = "HP Laptop",
                    Quantity = 2000
                });
                customer.Orders.Add(new Order
                {
                    Description = "Sherlock Holmes DVD",
                    Quantity = 35
                });

                //------------------------------------------------------------------------------------------------------
                Customer customer1 = new Customer { FirstName = "Jennifer", LastName = "ANISTON" };
                customer1.Orders.Add(new Order
                {
                    Description = "Kalem",
                    Quantity = 56
                });
                customer1.Orders.Add(new Order
                {
                    Description = "Silgi",
                    Quantity = 77
                });

                context.Customers.Add(customer);
                context.Customers.Add(customer1);
            }
        }
    }
}
