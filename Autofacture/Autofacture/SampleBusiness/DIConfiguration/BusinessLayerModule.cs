using Autofac;

namespace Autofacture.SampleBusiness.DIConfiguration {
    public class BusinessLayerModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
        }
    }
}