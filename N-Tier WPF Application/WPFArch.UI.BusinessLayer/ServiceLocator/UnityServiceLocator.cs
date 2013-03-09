using Microsoft.Practices.Unity;
using WPFArch.UI.BusinessLayer.Interface;

namespace WPFArch.UI.BusinessLayer.ServiceLocator
{
    class UnityServiceLocator : IServiceLocator
    {
        private readonly UnityContainer _container;

        public UnityServiceLocator()
        {
            _container = new UnityContainer();
        }
    
        void IServiceLocator.Register<TInterface, TImplementation>()
        {
            _container.RegisterType<TInterface, TImplementation>();
        }

        TInterface IServiceLocator.Get<TInterface>()
        {
            return _container.Resolve<TInterface>();
        }
    }
}
