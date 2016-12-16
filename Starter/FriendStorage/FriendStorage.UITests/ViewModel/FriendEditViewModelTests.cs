using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendStorage.UITests.Extensions;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class FriendEditViewModelTests
    {
        FriendEditViewModel friendEditViewModel;
        Mock<IFriendDataProvider> friendDataServiceMock;
        public void FriendEditViewModelTests_Setup()
        {
           friendDataServiceMock =  new Mock<IFriendDataProvider>();
           friendDataServiceMock.Setup(fDS => fDS.GetFriendById(It.IsAny<int>())).Returns<int>((friendId)=>new Friend { Id=friendId});
           friendEditViewModel = new FriendEditViewModel(friendDataServiceMock.Object);
        }
        [TestMethod]
        public void ShouldGetFriendWhenCalledLoad()
        {
            FriendEditViewModelTests_Setup();

            friendEditViewModel.Load(7);

            Assert.IsNotNull(friendEditViewModel.Friend);
            Assert.AreEqual(friendEditViewModel.Friend.Id, 7);

            friendDataServiceMock.Verify(dp => dp.GetFriendById(7), Times.Once);
        }
        [TestMethod]
        public void ShouldRaisePropertyChangedEventForFriend()
        {
            FriendEditViewModelTests_Setup(); 
            Action action = ()=>{
                friendEditViewModel.Load(7);
            };
          var isFired = friendEditViewModel.IsPropertyChangedFired(action, nameof(friendEditViewModel.Friend));
            Assert.IsTrue(isFired);
        }
    }
}
