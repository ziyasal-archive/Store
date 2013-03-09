using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFArch.UI.BusinessLayer.Common;
using WPFArch.UI.BusinessLayer.Common;
using WPFArch.UI.BusinessLayer.CustomerServiceReference;
using WPFArch.UI.BusinessLayer.Interface;
using WPFArch.UI.BusinessLayer.ServiceLocator;
using WPFArch.UI.BusinessLayer.ServiceManagerImpl;
using WPFArch.UI.BusinessLayer.ServiceManagerInterface;

namespace WPFArch.UI.BusinessLayer.ViewModel
{
    public class CustomerListViewModel : ViewModelBase
    {
        private readonly ICustomerServiceManager _customerServiceManager;
        private static CustomerListViewModel __instance;
        private CustomerViewModel _selectedCustomer;
        private ObservableCollection<CustomerViewModel> _customerList;
        private ICommand _showAddCommand;

        private CustomerListViewModel()
            : this(new CustomerServiceManager())
        {

        }
        public CustomerListViewModel(ICustomerServiceManager customerServiceManager)
        {
            _customerServiceManager = customerServiceManager;
            GetCustomers();
        }

        public ObservableCollection<CustomerViewModel> CustomerList
        {
            get
            {
                return _customerList;
            }
            set
            {
                _customerList = value;
                NotifyPropertyChanged(model => CustomerList);
            }
        }

        public CustomerViewModel SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                if (_selectedCustomer != null)
                    _selectedCustomer.GetOrders();
                NotifyPropertyChanged(model => SelectedCustomer);
            }
        }

        public ICommand ShowAddCommand
        {
            get
            {
                if (_showAddCommand == null)
                {
                    _showAddCommand = new CommandBase(i => ShowAddDialog(), null);
                }
                return _showAddCommand;
            }
        }

        public static CustomerListViewModel Instance()
        {
            return __instance ?? (__instance = new CustomerListViewModel());
        }

        internal void GetCustomers()
        {
            ObservableCollection<CustomerViewModel> temp = new ObservableCollection<CustomerViewModel>();

            _customerServiceManager.GetCustomers((response, exception) =>
                                                     {
                                                         if (exception == null)
                                                         {
                                                             List<CustomerDto> customers = response.Customers;
                                                             foreach (CustomerDto customerDto in customers)
                                                             {
                                                                 CustomerViewModel customerViewModel = new CustomerViewModel(customerDto);
                                                                 temp.Add(customerViewModel);
                                                             }
                                                             CustomerList = temp;
                                                         }
                                                     });
        }

        private void ShowAddDialog()
        {
            CustomerViewModel customer = new CustomerViewModel
                                             {
                                                 Mode = Mode.Add
                                             };
            //Get from Unity Container
            IModalDialog dialog = ServiceProvider.Instance.Get<IModalDialog>();
            dialog.BindViewModel(customer);
            dialog.ShowDialog();
        }

    }
}