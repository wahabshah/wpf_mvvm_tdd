using System;
using System.Collections.Generic;
using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;

namespace FriendStorage.UI.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
        public INavigationViewModel NavigationViewModel { get; private set; }
        public MainViewModel(INavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
        }      
        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
   
}
