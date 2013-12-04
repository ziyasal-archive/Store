using Autofac;
using AutoMapper;

namespace Autofacture.SampleBusiness.DIConfiguration {
    public class AutoMapperModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AssignableTo<Profile>()
                .As<Profile>();

            builder.Register(context => Mapper.Engine).As<IMappingEngine>();
            builder.RegisterType<TypeMapFactory>().As<ITypeMapFactory>().SingleInstance();
            builder.Register(c => AutoMapper.Mappers.MapperRegistry.Mappers).SingleInstance();


            builder.RegisterType<ConfigurationStore>()
                .As<ConfigurationStore>()
                .AsImplementedInterfaces().SingleInstance();
        }
    }
}