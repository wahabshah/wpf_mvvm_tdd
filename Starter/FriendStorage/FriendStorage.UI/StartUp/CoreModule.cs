using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;
using Ninject.Extensions.Factory;
using Ninject.Modules;
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
            this.Bind<MainWindow>().ToSelf();
            this.Bind<MainViewModel>().ToSelf();
            this.Bind<INavigationViewModel>().To<NavigationViewModel>();
            this.Bind<INavigationDataProvider>().To<NavigationDataProvider>();          
        }
    }
}
