using System;
using FriendStorage.UI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using FriendStorage.UI.Events;
using System.Collections.Generic;
using System.Linq;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class MainViewModelTests
    {
        private Mock<IEventAggregator> _eventAggregatorStub;
        private OpenFriendEditViewEvent _openFriendEditViewEvent;
        public MainViewModel _mainViewModel { get; set; }
        public Mock<INavigationViewModel> _navigationViewModelMock { get; set; }
        private List<Mock<IFriendEditViewModel>> _friendEditViewModelMocks;
        public void MainViewModelTests_Setup()
        {
            _navigationViewModelMock = new Mock<INavigationViewModel>();
            _eventAggregatorStub = new Mock<IEventAggregator>();
            _openFriendEditViewEvent = new Mock<OpenFriendEditViewEvent>().Object;
            _eventAggregatorStub.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>()).Returns(_openFriendEditViewEvent);
            _friendEditViewModelMocks = new List<Mock<IFriendEditViewModel>>();
            _mainViewModel = new MainViewModel(_navigationViewModelMock.Object,CreateFreindEditVieModel, _eventAggregatorStub.Object);
        }

        private IFriendEditViewModel CreateFreindEditVieModel()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
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
            _friendEditViewModelMocks.First().Verify(vm => vm.Load(), Times.Once);
        }
    }
}
