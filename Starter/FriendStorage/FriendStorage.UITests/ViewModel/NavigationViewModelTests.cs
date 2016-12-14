using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using System.Collections.Generic;
using System.Linq;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class NavigationViewModelTests
    {
        public NavigationViewModel _NavigationVM { get; set; }
        
        public void NavigationViewModelTests_Setup()
        {
            var fakeRepository = new Mock<INavigationDataProvider>();
            fakeRepository.Setup(m => m.GetAllFriends()).Returns(new List<LookUpItem>() { new LookUpItem() { Id = 1, DisplayMember = "Wahab Shah" }, new LookUpItem() { Id = 2, DisplayMember = "Sajid Khan" } });
            var eventAggregatorStub = new Mock<IEventAggregator>();
            _NavigationVM = new NavigationViewModel(fakeRepository.Object,eventAggregatorStub.Object);
        }
        [TestMethod]
        public void Calling_Load_Should_Get_Friends()
        {
            NavigationViewModelTests_Setup();

            _NavigationVM.Load();

            Assert.AreEqual(_NavigationVM.Friends.Count, 2);
            var friend = _NavigationVM.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.IsNotNull(friend);
            Assert.AreEqual(friend.DisplayMember,"Wahab Shah");
            friend = _NavigationVM.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.IsNotNull(friend);
            Assert.AreEqual(friend.DisplayMember, "Sajid Khan");
        }
        [TestMethod]
        public void ShouldLoadFriendsOnlyOnce()
        {
            NavigationViewModelTests_Setup();

            _NavigationVM.Load();
            _NavigationVM.Load();

            Assert.AreEqual(_NavigationVM.Friends.Count, 2);
        }
    }   
}
