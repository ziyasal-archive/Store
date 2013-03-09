using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFArch.UI.BusinessLayer.Common;
using WPFArch.UI.BusinessLayer.Common;
using WPFArch.UI.BusinessLayer.CustomerServiceReference;
using WPFArch.UI.BusinessLayer.Interface;
using WPFArch.UI.BusinessLayer.OrderServiceReference;
using WPFArch.UI.BusinessLayer.ServiceLocator;
using WPFArch.UI.BusinessLayer.ServiceManagerImpl;
using WPFArch.UI.BusinessLayer.ServiceManagerInterface;

namespace WPFArch.UI.BusinessLayer.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly IOrderServiceManager _orderServiceManager;
        private ICustomerServiceManager _customerServiceManager;
        private string _firstName;
        private string _lastName;
        private ObservableCollection<OrderViewModel> _orders;

        private ICommand _showEditCommand;
        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private CustomerViewModel _originalValue;

        public int CustomerId { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged(model => FirstName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyPropertyChanged(model => LastName);
            }
        }

        public Mode Mode { get; set; }

        public CustomerListViewModel Container
        {
            get { return CustomerListViewModel.Instance(); }
        }

        public ObservableCollection<OrderViewModel> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                NotifyPropertyChanged(model => Orders);
            }
        }

        public ICommand ShowEditCommand
        {
            get { return _showEditCommand ?? (_showEditCommand = new CommandBase(i => ShowEditDialog(), null)); }
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

        public CustomerViewModel(CustomerDto customerDto)
        {
            CustomerId = customerDto.CustomerId;
            _firstName = customerDto.FirstName;
            _lastName = customerDto.LastName;
            _originalValue = (CustomerViewModel)MemberwiseClone();
            _orderServiceManager = ServiceProvider.Instance.Get<IOrderServiceManager>();
            _customerServiceManager = ServiceProvider.Instance.Get<ICustomerServiceManager>();
        }

        internal CustomerViewModel()
            : this(new OrderServiceManager(), new CustomerServiceManager())
        {
        }

        public CustomerViewModel(IOrderServiceManager orderServiceManager, ICustomerServiceManager customerServiceManager)
        {
            _orderServiceManager = orderServiceManager;
            _customerServiceManager = customerServiceManager;
        }

        internal void GetOrders()
        {
            ObservableCollection<OrderViewModel> temp = new ObservableCollection<OrderViewModel>();

            _orderServiceManager.GetOrders(CustomerId, (response, exception) =>
                                                                                  {
                                                                                      if (exception == null)
                                                                                      {
                                                                                          foreach (OrderDto orderDto in response.Orders)
                                                                                          {
                                                                                              OrderViewModel order = new OrderViewModel(orderDto)
                                                                                              {
                                                                                                  Customer = this
                                                                                              };
                                                                                              temp.Add(order);
                                                                                          }
                                                                                          Orders = temp;
                                                                                      }

                                                                                  });
        }

        private void ShowEditDialog()
        {
            Mode = Mode.Edit;

            IModalDialog dialog = ServiceProvider.Instance.Get<IModalDialog>();
            dialog.BindViewModel(this);
            dialog.ShowDialog();
        }

        private void Update()
        {
            if (Mode == Mode.Add)
            {
                _customerServiceManager.AddCustomer(FirstName, LastName);
                //refresh the view
                Container.GetCustomers();
            }
            else if (Mode == Mode.Edit)
            {
                _customerServiceManager.UpdateCustomer(new CustomerDto
                                        {
                                            CustomerId = CustomerId,
                                            FirstName = FirstName,
                                            LastName = LastName
                                        });
                _originalValue = (CustomerViewModel)MemberwiseClone();
            }
        }

        private void Delete()
        {
            _customerServiceManager.DeleteCustomer(CustomerId);
            Container.GetCustomers();
        }

        private void Undo()
        {
            if (Mode == Mode.Edit)
            {
                FirstName = _originalValue.FirstName;
                LastName = _originalValue.LastName;
            }
        }
    }
}
