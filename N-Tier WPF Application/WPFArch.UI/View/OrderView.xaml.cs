using System.Windows;
using WPF.Themes;

namespace WPFArch.UI.View
{
    public partial class OrderView
    {
        public OrderView()
        {
            InitializeComponent();
            int themeIndex = ((App)Application.Current).ThemeIndex;
            this.ApplyTheme(ThemeManager.GetThemes()[themeIndex]);
        }

        private void BtnUpdateClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
