using HurLite.BrowserSelector.Globals;
using HurLite.BrowserSelector.Helpers;
using HurLite.BrowserSelector.Views;
using HurLite.BrowserSelector.Views.ViewModels;
using System.Windows;

namespace HurLite.BrowserSelector
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _mainWindow;
        private MainViewModel viewModel;
        //private readonly Settings settings = SettingsFile.GetSettings();

        protected override void OnStartup(StartupEventArgs e)
        {
            var x = CliArgs.GatherInfo(e.Args, false);

            CurrentLink.Value = x.Url;
            viewModel = new MainViewModel();

            _mainWindow = new MainWindow(viewModel.settings)
            {
                DataContext = viewModel
            };

            _mainWindow.Init(x);
        }


    }
}