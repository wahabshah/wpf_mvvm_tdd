using System;
using FriendStorage.UI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using FriendStorage.UI.Events;
using System.Collections.Generic;
using System.Linq;
using FriendStorage.UITests.Extensions;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class MainViewModelTests
    {
        private Mock<IEventAggregator> _eventAggregatorStub;
        private OpenFriendEditViewEvent _openFriendEditViewEvent;
        public MainViewModel _mainViewModel { get; set; }
        public Mock<INavigationViewModel> _navigationViewModelMock { get; set; }
        private List<Mock<IFriendEditViewModel>> _friendEditViewModelMocks;  /* To store return type of Func to create IFriendEditViewModel*/
        public void MainViewModelTests_Setup()
        {
            _navigationViewModelMock = new Mock<INavigationViewModel>();
            _eventAggregatorStub = new Mock<IEventAggregator>();
            _openFriendEditViewEvent = new OpenFriendEditViewEvent();
            _eventAggregatorStub.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>()).Returns(_openFriendEditViewEvent);
            _friendEditViewModelMocks = new List<Mock<IFriendEditViewModel>>();
            _mainViewModel = new MainViewModel(_navigationViewModelMock.Object,CreateFriendEditVieModel, _eventAggregatorStub.Object);
        }

        private IFriendEditViewModel CreateFriendEditVieModel()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
            friendEditViewModelMock.Setup(fEVM => fEVM.Load(It.IsAny<int>())).Callback<int>((friendId)=> {
            friendEditViewModelMock.Setup(fEVM => fEVM.Friend).Returns(new Model.Friend() { Id = friendId }); });
           
            _friendEditViewModelMocks.Add(friendEditViewModelMock);
            return friendEditViewModelMock.Object;
        }

        [TestMethod]
        public void ShouldCallLoadMethodOfNavigationalViewModel()
        {
            MainViewModelTests_Setup();          
            _mainViewModel.Load();

            _navigationViewModelMock.Verify(vm=>vm.Load(),Times.Once);
        }
        [TestMethod]
        public void ShouldAddFriendEditViewModelAndLoadAndSelectIt()
        {
            MainViewModelTests_Setup();
            const int friendId = 7;
            _openFriendEditViewEvent.Publish(friendId);

            Assert.AreEqual(1, _mainViewModel.FriendEditViewModels.Count);
            var friendEditVM = _mainViewModel.FriendEditViewModels.First();
            Assert.AreEqual(friendEditVM, _mainViewModel.SelectedFriendEditViewModel);
            _friendEditViewModelMocks.First().Verify(vm => vm.Load(friendId), Times.Once);
        }
        [TestMethod]
        public void ShouldAddFriendEditViewModelOnce()
        {
            MainViewModelTests_Setup();
            const int friendId = 7;
            _openFriendEditViewEvent.Publish(friendId);
            _openFriendEditViewEvent.Publish(friendId);

            Assert.AreEqual(1, _mainViewModel.FriendEditViewModels.Count);
        }
        [TestMethod]
        public void ShouldRaisePropertyChangedEventForSelectedFriendEditViewModel()
        {
            MainViewModelTests_Setup();
            var friendEditVMStub = new Mock<IFriendEditViewModel>();
            Action action = () =>
            {
                 _mainViewModel.SelectedFriendEditViewModel = friendEditVMStub.Object;
            };
           var isFired =  _mainViewModel.IsPropertyChangedFired(action, nameof(_mainViewModel.SelectedFriendEditViewModel));
            Assert.IsTrue(isFired);
        }
    }
}
