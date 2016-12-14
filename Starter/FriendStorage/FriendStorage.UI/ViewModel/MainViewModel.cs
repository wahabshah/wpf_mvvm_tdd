using System;
using System.Collections.Generic;
using System.ComponentModel;
using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using Prism.Events;
using FriendStorage.UI.Events;
using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;

        public INavigationViewModel NavigationViewModel { get; private set; }
        public ObservableCollection<FriendEditViewModel> FriendEditViewModels{get;set;}
        public IFriendEditViewModel _selectedFriendEditViewModel;
        private Func<IFriendEditViewModel> _friendEditVMCreator;

        public IFriendEditViewModel SelectedFriendEditViewModel
        {
            get
            {
                return _selectedFriendEditViewModel;
            }
            set
            {
                _selectedFriendEditViewModel = value;
            }
        }

        public MainViewModel(INavigationViewModel navigationViewModel,Func<IFriendEditViewModel> friendEditVMCreator,IEventAggregator eventAggregator)
        {
            NavigationViewModel = navigationViewModel;
            FriendEditViewModels = new ObservableCollection<FriendEditViewModel>();
            _friendEditVMCreator = friendEditVMCreator;       
            _eventAggregator = eventAggregator;
            //subscribe
            //PropertyChanged += FriendEditViewModel_PropertyChanged;
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>().Subscribe(ShowFriend);
        }

        private void ShowFriend(int friendId)
        {
            throw new NotImplementedException();
        }

        //private void FriendEditViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    switch (e.PropertyName)
        //    {
        //        case "FriendDetails":

        //            break;
        //        default:
        //            break;
        //    }
        //}

        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
   
}
