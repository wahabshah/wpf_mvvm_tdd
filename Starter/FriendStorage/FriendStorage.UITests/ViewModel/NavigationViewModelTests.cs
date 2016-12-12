using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

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

            Assert.AreEqual(navigationVM.Friends.Count, 1);
        }
    }
    public class NavigationDataProviderMock : INavigationDataProvider
    {
        public IEnumerable<Friend> GetAllFriends()
        {
            List<Friend> friends = new List<Friend>()
            {
                new Friend() {FirstName="Wahab" ,LastName="Shah"}
            };
            return friends;
        }
    }
}
