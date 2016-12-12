using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendStorage.Model;
using FriendStorage.DataAccess;

namespace FriendStorage.UI.DataProvider
{
    public class NavigationDataProvider : INavigationDataProvider
    {
        public Func<IDataService> _dataService;
        public NavigationDataProvider(Func<IDataService> repository)
        {
            _dataService = repository;
        }
      
        public IEnumerable<LookUpItem> GetAllFriends()
        {
            using (var dataService = _dataService())
            {
               return dataService.GetAllFriends();
            }
        }
    }
}
