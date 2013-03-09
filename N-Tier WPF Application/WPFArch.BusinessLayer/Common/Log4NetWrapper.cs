using System;
using AOPify;

namespace WPFArch.BusinessLayer.Common
{
    public class Log4NetWrapper : IAOPLogger
    {
        public void Log(string format, params object[] args)
        {
            CommonLogManager.Log.Info(format.FormatWith(args));
        }

        public void Error(Exception exception)
        {
            CommonLogManager.Log.Info(exception);
        }

        public void Error(Exception exception, string message)
        {
            CommonLogManager.Log.Info(message,exception);
        }

        public void Info(string format, params object[] args)
        {
            CommonLogManager.Log.Info(format.FormatWith(args));
        }
    }
}
