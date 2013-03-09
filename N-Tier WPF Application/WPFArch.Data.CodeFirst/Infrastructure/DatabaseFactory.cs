using System;
using System.Threading;
using System.Web;
using WPFArch.Data.CodeFirst.Infrastructure;
using WPFArch.Data.CodeFirst.Models;

namespace WPFArch.Data.CodeFirst.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {

        private static readonly object LockObj = new object();
        private WPFRealWorldContext _dataContext;
        readonly LocalDataStoreSlot _dataContextSlot = Thread.GetNamedDataSlot("dataContext");

        public WPFRealWorldContext Get()
        {
            return DataContext;
        }

        protected override void DisposeCore()
        {
            //if (_dataContext != null)
            //    _dataContext.Dispose();
        }

        WPFRealWorldContext NewDataContext()
        {
            return new WPFRealWorldContext();
        }


        WPFRealWorldContext DataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    lock (LockObj)
                    {
                        if (_dataContext == null)
                        {
                            if (HttpContext.Current == null)
                            {
                                object data = Thread.GetData(_dataContextSlot);
                                if (data == null)
                                {
                                    data = NewDataContext();
                                    Thread.SetData(_dataContextSlot, data);
                                }
                                _dataContext = (WPFRealWorldContext)data;
                            }
                            else if (HttpContext.Current.Items.Contains("__datacontext"))
                                _dataContext = (WPFRealWorldContext)HttpContext.Current.Items["__datacontext"];
                            else
                            {
                                _dataContext = NewDataContext();
                                if (HttpContext.Current != null)
                                    HttpContext.Current.Items["__datacontext"] = _dataContext;
                            }
                            return _dataContext;
                        }
                        return _dataContext;
                    }
                }
                return _dataContext;
            }
        }
    }
}