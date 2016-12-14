using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class NavigationItemViewModelTests
    {

        [TestMethod]
        public void ShouldPublishOpenFriendEditViewEvent()
        {
            const int friendId = 7;
            var eventMock = new Mock<OpenFriendEditViewEvent>();
            var eventAggregator = new Mock<IEventAggregator>();
            eventAggregator.Setup(e => e.GetEvent<OpenFriendEditViewEvent>()).Returns(eventMock.Object);

            var navigationItemViewModel = new NavigationItemViewModel(friendId, "", eventAggregator.Object);
            navigationItemViewModel.OpenFriendEditViewCommand.Execute(null);

            eventMock.Verify(e => e.Publish(friendId), Times.Once);
        }
        

    }
}
