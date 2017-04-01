using System;
using Laboration_3.Models;
using Laboration_3.Router;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Laboration_3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyRoomsView : Page
    {
        
        public MyRoomsView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ShowRoomsList();
        }

        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.RevertToCheckpoint();
        }
        private void ReloadBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MyRoomsList.Items.Clear();
            ShowRoomsList();
        }

        private void HomeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.Route("MainPage");
        }

        private void ShowRoomsList()
        {
            if (RoomRepository.offlineStorage != null)
            {
                foreach (KeyValuePair<int, Room> pair in RoomRepository.offlineStorage)
                {
                    var room = pair.Value;

                    var listItem = new ListViewItem
                    {
                        Content = "ID: " + room.Id + " Name: " + room.Name,
                        Foreground = new SolidColorBrush(Windows.UI.Colors.Honeydew)
                    };
                    MyRoomsList.Items.Add(listItem);
                }
            }
            MyRoomsList.UpdateLayout();
        }

        private void MyRoomsList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            String roomString = (String)e.ClickedItem;
            Debug.Write(roomString);
            int id = Convert.ToInt32(roomString[4]);
            if (char.IsNumber(roomString[5]))
            {
                var tmp = Convert.ToInt32(roomString[5]);
                id = id + tmp;
            }

            App.Router.CheckpointRoute("MyRoomsView");
            App.Router.Route("EditRoomView", new EditRoomViewModel(id));

        }
    }
}
