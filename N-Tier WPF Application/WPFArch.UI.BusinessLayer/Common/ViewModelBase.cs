using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace WPFArch.UI.BusinessLayer.Common
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(Expression<Func<object, object>> expression)
        {
            string method = ExpressionHelper.GetMethodName(expression);

            if (!string.IsNullOrEmpty(method))
            {
                NotifyProperty(method);
            }
        }

        private void NotifyProperty(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
