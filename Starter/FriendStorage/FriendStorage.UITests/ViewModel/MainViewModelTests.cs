using FriendStorage.UI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void ShouldCallLoadMethodOfNavigationalViewModel()
        {
            var navigationViewModelMock = new NavigationViewModelMock();
            var mainViewModel = new MainViewModel(navigationViewModelMock);
            mainViewModel.Load();

            Assert.IsTrue(navigationViewModelMock.LoadHasBeenCalled);
        }
        public class NavigationViewModelMock : INavigationViewModel
        {
            public bool LoadHasBeenCalled { get; set; }
            public void Load()
            {
                LoadHasBeenCalled = true;
            }
        }
    }
}
