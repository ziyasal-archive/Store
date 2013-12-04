using Autofac;
using AutoMapper;

namespace Autofacture {
    public class AutofacBootstrapper {
        public static IContainer Run() {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AssignableTo<Profile>()
                .As<Profile>();

            builder.Register(c => Mapper.Engine).As<IMappingEngine>();
            builder.RegisterType<TypeMapFactory>().As<ITypeMapFactory>();
            builder.Register(c => AutoMapper.Mappers.MapperRegistry.Mappers);

            builder.RegisterType<ConfigurationStore>()
                .As<ConfigurationStore>()
                .As<IConfigurationProvider>()
                .As<IConfiguration>();

            return builder.Build();
        }
    }
}