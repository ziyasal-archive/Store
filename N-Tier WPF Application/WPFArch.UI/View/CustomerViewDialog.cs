using System;
using WPFArch.UI.BusinessLayer.Interface;

namespace WPFArch.UI.View
{
    public class CustomerViewDialog : IModalDialog
    {
        private CustomerView _view;

        void IModalDialog.BindViewModel<TViewModel>(TViewModel viewModel)
        {
            GetDialog().DataContext = viewModel;
        }

        void IModalDialog.ShowDialog()
        {
            GetDialog().ShowDialog();
        }

        void IModalDialog.Close()
        {
            GetDialog().Close();
        }        

        private CustomerView GetDialog()
        {
            if (_view == null)
            {
                //create the view if the view does not exist
                _view = new CustomerView();
                _view.Closed += ViewClosed;
            }
            return _view;
        }

        void ViewClosed(object sender, EventArgs e)
        {
            _view = null;
        }

    }
}