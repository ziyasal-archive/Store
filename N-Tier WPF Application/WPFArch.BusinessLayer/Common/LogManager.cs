using log4net;

namespace WPFArch.BusinessLayer.Common
{
    public class CommonLogManager
    {
        private static ILog __logger;
        public static ILog Log
        {
            get { return __logger ?? (__logger = LogManager.GetLogger(typeof(CommonLogManager))); }
        }
    }
}