using Navigation.Example.View;
using Navigation.Example.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Navigation.Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow mainWindow;
        private MainWindowViewModel viewModel;

        public App(MainWindow mainWindow, MainWindowViewModel viewModel)
        {
            mainWindow.DataContext = viewModel;

            this.mainWindow = mainWindow;
            this.viewModel = viewModel;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
