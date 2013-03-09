using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using Elmah;

namespace WPFArch.WCF.ServiceHost.Elmah
{
    public class ElmahErrorHandler : IErrorHandler
    {
        #region IErrorHandler Members

        public bool HandleError(Exception error)
        {
            return false;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error == null)
            {
                return;
            }
            if (HttpContext.Current == null)
            {
                return;
            }
            ErrorSignal.FromCurrentContext().Raise(error);
        }

        #endregion
    }
}