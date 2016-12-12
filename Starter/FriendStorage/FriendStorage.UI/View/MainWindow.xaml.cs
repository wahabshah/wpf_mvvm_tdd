using FriendStorage.UI.ViewModel;
using System.Windows;

namespace FriendStorage.UI.View
{
  public partial class MainWindow : Window
  {
        private MainViewModel _mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Load();
        }
    }
}
