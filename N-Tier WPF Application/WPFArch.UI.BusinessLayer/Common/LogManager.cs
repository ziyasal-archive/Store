using log4net;

namespace WPFArch.UI.BusinessLayer.Common
{
    public class CommonLogManager
    {
        protected static ILog log;
        public static ILog Log
        {
            get
            {
                if (log == null)
                {
                    log = LogManager.GetLogger(typeof(CommonLogManager));
                }
                return log;
            }
        }
    }
}