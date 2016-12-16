using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendStorage.Model;
using FriendStorage.DataAccess;

namespace FriendStorage.UI.DataProvider
{
    public class FriendDataProvider : IFriendDataProvider
    {
        public Func<IDataService> _dataService;
        public FriendDataProvider(Func<IDataService> dataService)
        {
            _dataService = dataService;
        }
        public void DeleteFriend(int friendId)
        {
            using (var dataservice = _dataService())
            {
                dataservice.DeleteFriend(friendId);
            }
        }

        public Friend GetFriendById(int friendId)
        {
            Friend friend;
            using (var dataService = _dataService())
            {
               friend = dataService.GetFriendById(friendId);
            }
            return friend;
        }

        public void SaveFriend(Friend friend)
        {
            using (var dataService = _dataService())
            {
                dataService.SaveFriend(friend);
            }
        }
    }
}
