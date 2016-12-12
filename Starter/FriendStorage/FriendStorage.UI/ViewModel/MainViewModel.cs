using System;
using System.Collections.Generic;
using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;

namespace FriendStorage.UI.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
        public MainViewModel()
        {
            //var repository = new FileDataService();
            //NavigationViewModel = new NavigationViewModel(repository);
        }
        public NavigationViewModel NavigationViewModel { get; private set; }
        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
   
}
