using InspectorTextBox.Example.View;
using InspectorTextBox.Example.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace InspectorTextBox.Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var viewModel = new MainWindowViewModel();
            var window = new MainWindow();

            window.DataContext = viewModel;

            window.Show();

            base.OnStartup(e);
        }
    }
}
