using System;
using System.Runtime.CompilerServices;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load();
    }
    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
