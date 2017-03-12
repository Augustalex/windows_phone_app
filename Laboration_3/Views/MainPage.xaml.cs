﻿using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Laboration_3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NewRoomBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //CoreApplicationView newView = CoreApplication.CreateNewView();
            //int newViewId = 0;
            //await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            //    Frame newFrame = new Frame();
            //    newFrame.Navigate(typeof(EditRoomView), null);
            //    Window.Current.Content = newFrame;
            //    Window.Current.Activate();

            //    newViewId = ApplicationView.GetForCurrentView().Id;

            //});

            //await ApplicationViewSwitcher.SwitchAsync(newViewId);

            App.Router.Route("EditRoomView", new EditRoomViewModel());
        }

        private void MyRoomBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
