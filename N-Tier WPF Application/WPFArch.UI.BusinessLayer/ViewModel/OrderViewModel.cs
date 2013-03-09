using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using WPFArch.UI.BusinessLayer.Common;
using WPFArch.UI.BusinessLayer.OrderServiceReference;
using WPFArch.UI.BusinessLayer.ServiceManagerImpl;
using WPFArch.UI.BusinessLayer.ServiceManagerInterface;

namespace WPFArch.UI.BusinessLayer.ViewModel
{
    public class OrderViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IOrderServiceManager _orderServiceManager;
        private string _description;
        private string _quantity;

        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private OrderViewModel _originalValue;

        public CustomerViewModel Customer { get; set; }
        public int OrderId { get; set; }

        public Mode Mode { get; set; }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged(model => Description);
            }
        }

        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value == "0" ? "1" : value;
                NotifyPropertyChanged(model => Quantity);
            }
        }



        public ICommand UpdateCommand
        {
            get { return _updateCommand ?? (_updateCommand = new CommandBase(i => Update(), null)); }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new CommandBase(i => Delete(), null)); }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new CommandBase(i => Undo(), null)); }
        }

        internal OrderViewModel(OrderDto orderDto)
        {
            OrderId = orderDto.OrderId;
            _description = orderDto.Description;
            _quantity = orderDto.Quantity.ToString(CultureInfo.InvariantCulture);
            _originalValue = (OrderViewModel)MemberwiseClone(); //Undo op
            _orderServiceManager = ServiceLocator.ServiceProvider.Instance.Get<IOrderServiceManager>();
        }

        internal OrderViewModel()
            : this(new OrderServiceManager())
        {
        }

        public OrderViewModel(IOrderServiceManager orderServiceManager)
        {
            _orderServiceManager = orderServiceManager;
        }

        private void Update()
        {
            if (Mode == Mode.Add)
            {
                _orderServiceManager.AddOrder(Customer.CustomerId, new OrderDto
                {
                    Description = Description,
                    Quantity = int.Parse(Quantity)
                });
                Customer.GetOrders();
            }
            else if (Mode == Mode.Edit)
            {
                _orderServiceManager.UpdateOrder(new OrderDto
                                {
                                    OrderId = OrderId,
                                    Description = Description,
                                    Quantity = int.Parse(Quantity)
                                });

                _originalValue = (OrderViewModel)MemberwiseClone();//undo op
            }
        }

        private void Delete()
        {
            _orderServiceManager.DeleteOrder(OrderId);
            Customer.GetOrders();
        }

        private void Undo()
        {
            if (Mode == Mode.Edit)
            {
                Description = _originalValue.Description;
                Quantity = _originalValue.Quantity;
            }
        }


        #region IDataErrorInfo Members

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Description")
                {
                    if (Description == null)  //must have an order description
                        return "Please enter a description";
                    if (Description.Trim() == string.Empty)
                        return "Description is Required";
                }
                else if (columnName == "Quantity")
                {
                    int quantity;
                    if (!int.TryParse(Quantity, out quantity))  //if not integer
                        return "Quantity must be an integer";
                    if (quantity < 1)
                        return "Quantity must be at least 1";
                }
                return null;
            }
        }

        string IDataErrorInfo.Error
        {
            get { return string.Empty; }
        }

        #endregion
    }
}