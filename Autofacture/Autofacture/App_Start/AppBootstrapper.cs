using Autofac;

namespace Autofacture.App_Start {
    public class AppBootstrapper {
        public static IContainer Run() {
            IContainer container = AutofacBootstrapper.Run();
            AutoMapperBootstrapper.Run(container);
            return container;
        }
    }
}