using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Color = Windows.UI.Color;

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
            ShowRoomsList();
        }

        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.Route("WallEditor");
        }

        private void HomeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.Route("MainPage");
        }

        private void ShowRoomsList()
        {
            for (int i = 0; i < RoomRepository.offlineStorage.Count; i++)
            {
                var room = RoomRepository.offlineStorage[i];
                var color = TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(("#9CC5A1"));
                var listViewItem = new ListViewItem
                {
                    Content = room.Name + room.Id,
                    Foreground = new SolidColorBrush((Color) color)
                };
                MyRoomsList.Items?.Add(listViewItem);
            }
        }
    }
}
