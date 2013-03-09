using System;
using System.Web;
using AOPify;
using Autofac;
using Autofac.Integration.Wcf;
using WPFArch.BusinessLayer.Common;
using WPFArch.BusinessLayer.Interface;
using WPFArch.BusinessLayer.ManagerImpl;
using WPFArch.Data.CodeFirst.IRepositories;
using WPFArch.Data.CodeFirst.Infrastructure;
using WPFArch.Data.CodeFirst.Models;
using WPFArch.Data.CodeFirst.Repositories;
using log4net.Config;

namespace WPFArch.WCF.ServiceHost
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //AutoFac Reqistration (:
            var builder = new ContainerBuilder();
            builder.Register(c => new DatabaseFactory()).As<IDatabaseFactory>();
            builder.Register(c => new Log4NetWrapper()).As<IAOPLogger>();
            builder.Register(c => new UnitOfWork(c.Resolve<IDatabaseFactory>())).As<IUnitOfWork>();
            builder.Register(c => new CustomerRepository(c.Resolve<IDatabaseFactory>())).As<ICustomerRepository>();
            builder.Register(c => new OrderRepository(c.Resolve<IDatabaseFactory>())).As<IOrderRepository>();
            builder.Register(c => new CustomerManager(c.Resolve<ICustomerRepository>(), c.Resolve<IAOPLogger>(), c.Resolve<IUnitOfWork>())).As<ICustomerManager>();
            builder.Register(c => new OrderManager(c.Resolve<IOrderRepository>(), c.Resolve<IAOPLogger>(), c.Resolve<IUnitOfWork>())).As<IOrderManager>();
            builder.Register(c => new CustomerService(c.Resolve<ICustomerManager>()));
            builder.Register(c => new OrderService(c.Resolve<ICustomerManager>(), c.Resolve<IOrderManager>()));

            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<WPFRealWorldContext>());
            AutofacHostFactory.Container = builder.Build();

#pragma warning disable 612,618
            DOMConfigurator.Configure(); // Configure log4net (:
#pragma warning restore 612,618

            CommonLogManager.Log.Info("Application Started");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}