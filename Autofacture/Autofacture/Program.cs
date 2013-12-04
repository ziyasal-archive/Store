using System;
using Autofac;
using Autofacture.App_Start;
using Autofacture.SampleBusiness;
using Autofacture.SampleBusiness.ViewModel;

namespace Autofacture {
    public class Program {

        static void Main() {

            IContainer container = AppBootstrapper.Run();
            IProductService productService = container.Resolve<IProductService>();
            ProductViewModel productViewModel = productService.GetProduct();

            Console.WriteLine("Product Id:{0}, Name:{1}", productViewModel.Id, productViewModel.Name);

            Console.ReadKey();
        }
    }
}
