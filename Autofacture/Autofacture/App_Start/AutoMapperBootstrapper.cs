using System.Collections.Generic;
using Autofac;
using AutoMapper;

namespace Autofacture.App_Start {
    public class AutoMapperBootstrapper {
        public static void Run(IContainer container) {
            // AutoMapper initialization
            Mapper.Initialize(x => {
                x.ConstructServicesUsing(container.Resolve);
                container.Resolve<IEnumerable<Profile>>().Each(x.AddProfile);
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}