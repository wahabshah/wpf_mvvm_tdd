﻿using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;
using System.Windows;

namespace FriendStorage.UI
{
  public partial class App : Application
  {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainViewModel = new MainViewModel();
            var mainWindow = new MainWindow(mainViewModel);
            mainWindow.Show();          
        }
    }
}
