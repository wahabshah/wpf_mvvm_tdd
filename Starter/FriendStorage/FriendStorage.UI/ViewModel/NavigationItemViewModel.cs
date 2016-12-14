using FriendStorage.Model;
using FriendStorage.UI.Command;
using FriendStorage.UI.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel
    {
        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            _eventAggregator = eventAggregator;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
        }
        private IEventAggregator _eventAggregator;
        public string DisplayMember { get; private set; }
        public int Id { get; private set; }
        public ICommand OpenFriendEditViewCommand { get; set; }       

        private void OnFriendEditViewExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>()
                            .Publish(Id);
        }
       
    }
}
