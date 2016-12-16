using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using Prism.Events;
using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public interface INavigationViewModel
    {
        void Load();
    }
    public class NavigationViewModel : ViewModelBase , INavigationViewModel
    {
        
        private INavigationDataProvider _dataService;
        public ObservableCollection<NavigationItemViewModel> Friends { get; private set; }
        public IEventAggregator _eventAggregator { get; set; }

        public NavigationViewModel(INavigationDataProvider dataService,IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
        }     
        public void Load()
        {
            Friends.Clear();
            foreach(var friend in _dataService.GetAllFriends())
            {
                Friends.Add(new NavigationItemViewModel(friend.Id, friend.DisplayMember,_eventAggregator));
            }
           
        }
    }
}
