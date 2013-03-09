using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AOPify;
using WPFArch.BusinessLayer.Interface;
using WPFArch.BusinessLayer.Mapper;
using WPFArch.Data.CodeFirst.IRepositories;
using WPFArch.Data.CodeFirst.Infrastructure;
using WPFArch.Data.CodeFirst.Models;
using WPFArch.WCF.DtoLibrary;
using WPFArch.WCF.DtoLibrary.Request.Customer;
using WPFArch.WCF.DtoLibrary.Request.Order;

namespace WPFArch.BusinessLayer.ManagerImpl
{
    public class CustomerManager : ManagerBase, ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAOPLogger _logger;
        public CustomerManager(ICustomerRepository customerRepository, IAOPLogger logger, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public List<CustomerDto> GetCustomers()
        {
            List<CustomerDto> result = null;

            AOPify.AOPify
                .Let
                .RegisterLogger(Log.It.For(this).Use(_logger))
                .Log(MethodBase.GetCurrentMethod())
                .Run(() =>
                         {
                             List<Customer> customers = _customerRepository.All.ToList();
                             result = customers.Select(customer => customer.ToCustomerDto()).ToList();
                         });

            return result;
        }

        public int AddCustomer(AddCustomerRequest request)
        {
            int result = default(int);
            Customer customer = request.CustomerDto.ToCustomer();

            AOPify.AOPify
                .Let
                .RegisterLogger(Log.It.For(this).Use(_logger))
                .Log(MethodBase.GetCurrentMethod())
                .Run(() =>
                         {
                             _customerRepository.Insert(customer);
                             SaveChanges();
                             result = customer.CustomerId;
                         });
            return result;
        }

        public void Update(UpdateCustomerRequest request)
        {
            AOPify.AOPify
               .Let
               .RegisterLogger(Log.It.For(this).Use(_logger))
               .Log(MethodBase.GetCurrentMethod())
                 .Run(() =>
                 {
                     _customerRepository.Update(request.CustomerDto.ToCustomer());
                     SaveChanges();
                 });

        }

        public void Delete(DeleteCustomerRequest request)
        {
            AOPify.AOPify
                 .Let
                 .RegisterLogger(Log.It.For(this).Use(_logger))
                 .Log(string.Format("START :Customer DELETE op started Type: {0}, Method:{1}", GetType().Name, MethodBase.GetCurrentMethod().Name),
                string.Format("END :Customer DELETE op ended Type: {0}, Method:{1} , CustomerID :{2}", GetType().Name, MethodBase.GetCurrentMethod().Name, request.CustomerID))
                 .Run(() =>
                 {
                     _customerRepository.Delete(request.CustomerID);
                     SaveChanges();
                 });

        }

        public List<OrderDto> GetOrders(GetOrderByCustomerReguest reguest)
        {
            List<OrderDto> result = null;

            AOPify.AOPify
                .Let
                .RegisterLogger(Log.It.For(this).Use(_logger))
                .Log(MethodBase.GetCurrentMethod())
                 .Run(() =>
                          {
                              Customer firstOrDefault = _customerRepository.AllIncluding(c => c.Orders).FirstOrDefault(
                                  c => c.CustomerId == reguest.CustomerID);
                              if (firstOrDefault != null)
                              {
                                  ICollection<Order> collection = firstOrDefault.Orders.ToList();
                                  result = collection.Select(order => order.ToOrderDto()).ToList();
                              }
                          });

            return result;
        }

        public int AddOrderToCustomer(AddOrderRequest request)
        {
            Order order = null;

            AOPify.AOPify
                .Let
                .RegisterLogger(Log.It.For(this).Use(_logger))
                .Log(string.Format("START :Customer ADDORDER op started Type: {0}, Method:{1}", GetType().Name, MethodBase.GetCurrentMethod().Name),
                        string.Format("END :Customer ADDORDER op ended Type: {0}, Method:{1} , CustomerID :{2}", GetType().Name, MethodBase.GetCurrentMethod().Name, request.CustomerID))
                .Run(() =>
                         {
                             Customer customer = _customerRepository.Find(request.CustomerID);
                             order = request.OrderDto.ToOrder();
                             if (customer != null) customer.Orders.Add(order);
                             SaveChanges();
                         });

            return order.OrderId;
        }
    }
}