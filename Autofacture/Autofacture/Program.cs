using System;
using Autofac;
using AutoMapper;
using Ploeh.AutoFixture;

namespace Autofacture {
    public class Program {

        static void Main() {

            IContainer container = AppBootstrapper.Run();
            IMappingEngine mappingEngine = container.Resolve<IMappingEngine>();
            IFixture fixture = new Fixture();
            OrderViewModel orderViewModel = mappingEngine.Map<Order, OrderViewModel>(fixture.Create<Order>());
            Console.WriteLine(orderViewModel.Quantity);

            Console.ReadKey();
        }
    }
}
