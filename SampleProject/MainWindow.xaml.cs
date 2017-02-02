using System.Windows;
using SampleProject.ViewModels;

namespace SampleProject
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel context;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            context = new MainViewModel();
            DataContext = context;
        }
    }
}