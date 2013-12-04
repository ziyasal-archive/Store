using Autofac;

namespace Autofacture {
    public class AppBootstrapper {
        public static IContainer Run() {
            IContainer container = AutofacBootstrapper.Run();
            AutoMapperBootstrapper.Run(container);
            return container;
        }
    }
}