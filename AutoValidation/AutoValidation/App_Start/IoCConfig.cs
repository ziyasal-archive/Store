using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoValidation.Infrastructure.Validation;
using FluentValidation;
using FluentValidation.Mvc;

namespace AutoValidation.App_Start {
    public class IoCConfig {
        public static void RegisterComponents() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>();

            //use IOC to map Validators to concrete objects...
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(result => builder.RegisterType(result.ValidatorType).As(result.InterfaceType));

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //setup fluent validation
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(container.Resolve<IValidatorFactory>()));
        }
    }
}