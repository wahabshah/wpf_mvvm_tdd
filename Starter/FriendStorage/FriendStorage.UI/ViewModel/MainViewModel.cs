using System;
using System.Collections.Generic;
using System.ComponentModel;
using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using Prism.Events;
using FriendStorage.UI.Events;
using System.Collections.ObjectModel;
using System.Linq;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;

        public INavigationViewModel NavigationViewModel { get; private set; }
        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels{get;set;}
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
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationViewModel navigationViewModel,
                             Func<IFriendEditViewModel> friendEditVMCreator,
                             IEventAggregator eventAggregator)
        {
            NavigationViewModel = navigationViewModel;
            FriendEditViewModels = new ObservableCollection<IFriendEditViewModel>();
            _friendEditVMCreator = friendEditVMCreator;       
            _eventAggregator = eventAggregator;
            //subscribe
            //PropertyChanged += FriendEditViewModel_PropertyChanged;
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>().Subscribe(OnOpenFriendEditView);
        }

        private void OnOpenFriendEditView(int friendId)
        {
            var friendVM = FriendEditViewModels.SingleOrDefault(fVM => fVM.Friend.Id == friendId);
            if (friendVM == null)
            {
                friendVM = _friendEditVMCreator();
                FriendEditViewModels.Add(friendVM);
                friendVM.Load(friendId);
            }
           SelectedFriendEditViewModel= friendVM;
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
