using System.Reflection;
using AOPify;
using WPFArch.BusinessLayer.Interface;
using WPFArch.BusinessLayer.Mapper;
using WPFArch.Data.CodeFirst.IRepositories;
using WPFArch.Data.CodeFirst.Infrastructure;
using WPFArch.WCF.DtoLibrary;
using WPFArch.WCF.DtoLibrary.Request.Order;

namespace WPFArch.BusinessLayer.ManagerImpl
{
    public class OrderManager : ManagerBase, IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAOPLogger _logger;

        public OrderManager(IOrderRepository orderRepository, IAOPLogger logger, IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public void Update(UpdateOrderRequest request)
        {
            AOPify.AOPify
                 .Let
                 .RegisterLogger(Log.It.For(this).Use(_logger))
                 .Log(string.Format("START :Order Update op started Type: {0}, Method:{1}", GetType().Name, MethodBase.GetCurrentMethod().Name),
                         string.Format("END :Order Update op ended Type: {0}, Method:{1} , OrderID :{2}", GetType().Name, MethodBase.GetCurrentMethod().Name, request.OrderDto.OrderId))
                 .Run(() =>
                          {
                              _orderRepository.Update(request.OrderDto.ToOrder());
                              SaveChanges();
                          });
        }

        public void Delete(DeleteOrderRequest request)
        {
            AOPify.AOPify
                .Let
                .RegisterLogger(Log.It.For(this).Use(_logger))
                .Log(string.Format("START :Order DELETE op started Type: {0}, Method:{1}", GetType().Name, MethodBase.GetCurrentMethod().Name),
                        string.Format("END :Order DELETE op ended Type: {0}, Method:{1} , OrderID :{2}", GetType().Name, MethodBase.GetCurrentMethod().Name, request.OrderID))
                .Run(() =>
                         {
                             _orderRepository.Delete(request.OrderID);
                             SaveChanges();
                         });
        }

        public OrderDto GetOrder(GetOrderRequest request)
        {
            OrderDto result = null;

            AOPify.AOPify
                 .Let
                 .RegisterLogger(Log.It.For(this).Use(_logger))
                 .Log(string.Format("START :Order GetOrder op started Type: {0}, Method:{1}", GetType().Name, MethodBase.GetCurrentMethod().Name),
                         string.Format("END :Order GetOrder op ended Type: {0}, Method:{1} , OrderID :{2}", GetType().Name, MethodBase.GetCurrentMethod().Name, request.OrderID))
                 .Run(() => result = _orderRepository.Find(request.OrderID).ToOrderDto());
            return result;
        }
    }
}