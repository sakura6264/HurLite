using HurLite.BrowserSelector.Converters;
using HurLite.BrowserSelector.Models;
using HurLite.BrowserSelector.Views.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace HurLite.BrowserSelector.Views
{
    /// <summary>
    /// Interaction logic for BrowsersList.xaml
    /// </summary>
    public partial class BrowsersList : UserControl
    {
        public BrowsersList()
        {
            InitializeComponent();
        }

        private void BtnArea_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tag = (sender as Border).Tag as Browser;
            (DataContext as BrowserListViewModel).OpenLink(tag);
            MinimizeWindow();
        }

        private void MinimizeWindow()
        {
            Application.Current.Shutdown();
        }

        private void AdditionalBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var x = Resources["TheCM"] as ContextMenu;
            x.PlacementTarget = btn;
            x.IsOpen = true;
            e.Handled = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var alt = (sender as MenuItem).Tag as AltLaunchParentConverter.AltLaunchParent;
            (DataContext as BrowserListViewModel).OpenAltLaunch(alt.AltLaunch, alt.Browser);
            MinimizeWindow();
        }
    }
}
