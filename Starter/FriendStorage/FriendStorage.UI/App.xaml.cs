using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.StartUp;
using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;
using Ninject;
using Ninject.Parameters;
using System;
using System.Windows;

namespace FriendStorage.UI
{
  public partial class App : Application
  {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // IDataService fileDataService = new FileDataService();
            // INavigationDataProvider navigationDataProvider = new NavigationDataProvider(()=>fileDataService);
            // INavigationViewModel navigationViewModel = new NavigationViewModel(navigationDataProvider);
            // MainViewModel mainViewModel = new MainViewModel(navigationViewModel);
            //var mainWindow = new MainWindow(mainViewModel);

            using (var kernel = new StandardKernel(new CoreModule()))
            {
               kernel.Bind<Func<IDataService>>().ToMethod(
               context =>
               () => kernel.Get<FileDataService>());

                var mainWindow = kernel.Get<MainWindow>();
                mainWindow.Show();
            }      
        }
    }
}
