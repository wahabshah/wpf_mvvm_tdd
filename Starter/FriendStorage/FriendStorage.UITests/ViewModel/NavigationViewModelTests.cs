using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class NavigationViewModelTests
    {
        [TestMethod]
        public void Calling_Load_Should_Get_Friends()
        {
            //var fakeRepository = new Mock<INavigationDataProvider>();
            //fakeRepository.Setup(m => m.GetAllFriends()).Returns(new List<Friend>() { new Friend() { FirstName = "Wahab", LastName = "Shah" } });
            //var navigationVM = new NavigationViewModel(fakeRepository.Object);
            var fakeRepository = new NavigationDataProviderMock();
            var navigationVM = new NavigationViewModel(fakeRepository);
            navigationVM.Load();

            Assert.AreEqual(navigationVM.Friends.Count, 2);
            var friend = navigationVM.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.IsNotNull(friend);
            Assert.AreEqual(friend.DisplayMember,"Wahab Shah");

            friend = navigationVM.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.IsNotNull(friend);
            Assert.AreEqual(friend.DisplayMember, "Sajid Khan");
        }
        [TestMethod]
        public void ShouldLoadFriendsOnlyOnce()
        {
            var fakeRepository = new NavigationDataProviderMock();
            var navigationVM = new NavigationViewModel(fakeRepository);
            navigationVM.Load();
            navigationVM.Load();

            Assert.AreEqual(navigationVM.Friends.Count, 2);
        }
    }
    public class NavigationDataProviderMock : INavigationDataProvider
    {
        public IEnumerable<LookUpItem> GetAllFriends()
        {
            yield return new LookUpItem() {Id=1, DisplayMember = "Wahab Shah" };
            yield return new LookUpItem() {Id=2, DisplayMember = "Sajid Khan"};
        }
    }
}
