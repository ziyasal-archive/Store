using System.Windows;
using System.Windows.Controls;
using WPFArch.UI.BusinessLayer.ServiceLocator;
using WPFArch.UI.BusinessLayer.ServiceManagerInterface;
using WPFArch.UI.BusinessLayer.ViewModel;

namespace WPFArch.UI.View
{
    public partial class OrderListView
    {
        public OrderListView()
        {
            InitializeComponent();
        }

        private void BtnAddOrderClick(object sender, RoutedEventArgs e)
        {
            OrderView view = new OrderView();
            OrderViewModel order = new OrderViewModel(ServiceProvider.Instance.Get<IOrderServiceManager>())
                                       {
                                           Customer = (CustomerViewModel)DataContext,
                                           Mode = Mode.Add
                                       };
            view.DataContext = order; 
            view.ShowDialog();
        }

        private void BtnEditOrderClick(object sender, RoutedEventArgs e)
        {
            OrderView view = new OrderView();
            OrderViewModel order = (OrderViewModel)((Button)sender).DataContext;
            order.Mode = Mode.Edit;
            view.DataContext = order;
            view.ShowDialog();
        }
    }
}
