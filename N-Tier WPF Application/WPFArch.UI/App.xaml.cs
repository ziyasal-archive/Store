using System.Windows;
using WPF.Themes;
using WPFArch.UI.BusinessLayer;
using WPFArch.UI.BusinessLayer.Common;
using WPFArch.UI.BusinessLayer.Interface;
using WPFArch.UI.BusinessLayer.ViewModel;
using WPFArch.UI.BusinessLayer.ServiceLocator;
using WPFArch.UI.View;
using log4net.Config;

namespace WPFArch.UI
{
    public partial class App
    {
        public int ThemeIndex { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            ThemeIndex = 5;
            base.OnStartup(e);

            MainWindow window = new MainWindow
                                    {
                                        DataContext = CustomerListViewModel.Instance()
                                    };
            window.ApplyTheme(ThemeManager.GetThemes()[ThemeIndex]);
            window.Show();

            BootStrapper.Initialize();
            ServiceProvider.Instance.Register<IModalDialog, CustomerViewDialog>();

#pragma warning disable 612,618
            DOMConfigurator.Configure(); // Configure log4net (:
#pragma warning restore 612,618

            CommonLogManager.Log.Info("Application Init executed..");
        }
    }
}
