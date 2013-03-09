using WPFArch.UI.BusinessLayer.Interface;
using WPFArch.UI.BusinessLayer.ServiceLocator;
using WPFArch.UI.BusinessLayer.ServiceManagerImpl;
using WPFArch.UI.BusinessLayer.ServiceManagerInterface;

namespace WPFArch.UI.BusinessLayer
{
    public class BootStrapper
    {
        public static void Initialize()
        {
            ServiceProvider.RegisterServiceLocator(new UnityServiceLocator());  
            ServiceProvider.Instance.Register<ICustomerServiceManager,CustomerServiceManager>();
            ServiceProvider.Instance.Register<IOrderServiceManager, OrderServiceManager>();
            //TODO: register view models
        }
    }
}
