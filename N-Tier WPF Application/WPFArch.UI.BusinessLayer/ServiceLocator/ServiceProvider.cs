using WPFArch.UI.BusinessLayer.Interface;

namespace WPFArch.UI.BusinessLayer.ServiceLocator
{
    public class ServiceProvider
    {
        public static IServiceLocator Instance { get; private set; }

        public static void RegisterServiceLocator(IServiceLocator serviceLocator)
        {
            Instance = serviceLocator;
        }
    }
}
