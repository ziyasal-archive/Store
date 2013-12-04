using Autofac;
using Autofacture.SampleBusiness.DIConfiguration;

namespace Autofacture.App_Start {
    public class AutofacBootstrapper {
        public static IContainer Run() {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<AutoMapperModule>();
            builder.RegisterModule<BusinessLayerModule>();

            return builder.Build();
        }
    }
}