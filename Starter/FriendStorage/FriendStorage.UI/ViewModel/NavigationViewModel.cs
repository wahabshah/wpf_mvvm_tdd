using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
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
        public ObservableCollection<LookUpItem> Friends { get; private set; }

        public NavigationViewModel(INavigationDataProvider dataService)
        {
            _dataService = dataService;
            Friends = new ObservableCollection<LookUpItem>();
        }     
        public void Load()
        {
            Friends.Clear();
           foreach(var friend in _dataService.GetAllFriends())
            {
                Friends.Add(friend);
            }
        }
    }
}
