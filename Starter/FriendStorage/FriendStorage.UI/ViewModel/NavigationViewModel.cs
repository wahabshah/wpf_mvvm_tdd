using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        private INavigationDataProvider _dataService;
        public ObservableCollection<Friend> Friends { get; private set; }

        public NavigationViewModel(INavigationDataProvider dataService)
        {
            _dataService = dataService;
            Friends = new ObservableCollection<Friend>();
        }     
        public void Load()
        {
           foreach(var friend in _dataService.GetAllFriends())
            {
                Friends.Add(friend);
            }
        }
    }
}
