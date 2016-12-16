using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using System;
using System.Runtime.CompilerServices;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        Friend Friend { get; }
        void Load(int friendId);
    }
    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        public IFriendDataProvider _friendDataService { get; set; }
        public FriendEditViewModel(IFriendDataProvider friendDataService)
        {
            _friendDataService = friendDataService;
        }
        private Friend _friend;
        public Friend Friend
        {
            get
            {
                return _friend;
            }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public void Load(int freindId)
        {
          Friend friend =  _friendDataService.GetFriendById(freindId);
             Friend = friend;
        }
    }
}
