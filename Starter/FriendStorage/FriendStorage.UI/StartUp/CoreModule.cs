using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UI.StartUp
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            this.Bind<MainWindow>().ToSelf();
            this.Bind<MainViewModel>().ToSelf();
            this.Bind<IFriendEditViewModel>().To<FriendEditViewModel>();
            this.Bind<INavigationViewModel>().To<NavigationViewModel>();
            this.Bind<IFriendDataProvider>().To<FriendDataProvider>();
            this.Bind<INavigationDataProvider>().To<NavigationDataProvider>();
            this.Bind<IDataService>().To<FileDataService>();
        }
        public static StandardKernel  Bootstrapper()
        {
                var Kernel = new StandardKernel(new CoreModule());
                return Kernel;
        }
    }
}
