using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Laboration_3.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Laboration_3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditRoomView : Page
    {
        private EditRoomViewModel ViewModel = new EditRoomViewModel();
        private double latitude;
        private double longitude;
        private Dictionary<string, object> dependencies = new Dictionary<string, object>();
        private uint? _desireAccuracyInMetersValue = 10;
        private int roomId;

        public EditRoomView()
        {
            this.InitializeComponent();
            this.roomId = EditRoomViewModel.RoomId;
            SelectTextInBox(nameBox);
        }

        public void SelectTextInBox(TextBox box)
        {
            box.Focus(FocusState.Keyboard);
            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.dependencies = e.Parameter as Dictionary<string, object>;
            ViewModel = GetContext();
            if (!GetContext().PageHasRoomId())
            {
                var room = new Room();
                
            }
            else
            {
                var room = RoomRepository.Fetch(roomId);
                nameBox.Text = room.Name;
                //todo: this shit
            }
        }

        private EditRoomViewModel GetContext()
        {
            if (this.dependencies.ContainsKey("context"))
            {
                return dependencies["context"] as EditRoomViewModel;
            }
            else
            {
                return new EditRoomViewModel();
            }
        }

        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.Route("MainPage");
        }

        private async void GetCoordsBtn_OnClick(object sender, RoutedEventArgs e)
        {

            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };

                    Geoposition pos = await geolocator.GetGeopositionAsync();

                    latitude = pos.Coordinate.Point.Position.Latitude;
                    longitude = pos.Coordinate.Point.Position.Longitude;

                    coordinatesBlock.Text = latitude.ToString() + " : " + longitude.ToString();
                    break;

                case GeolocationAccessStatus.Denied:
                    coordinatesBlock.Text = "Location request denied.";
                    break;

                case GeolocationAccessStatus.Unspecified:
                    coordinatesBlock.Text = "Unspecified error.";
                    break;
            }

        }

        private void WallEditorBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.Route("WallEditor");
        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (roomId == -1)
            {
                var thisRoom = new Room
                {
                    Id = GlobalClass.GetNextId(),
                    Name = nameBox.Text,
                    Description = descriptionBox.Text,
                    Coordinates = new []{latitude,longitude},
                    Size = Convert.ToInt32(sizeBox.Text)
                };
                RoomRepository.Save(thisRoom);
            }
            else
            {
                var tempRoom = RoomRepository.Fetch(roomId);
                RoomRepository.Remove(roomId);
                tempRoom.Id = roomId;
                tempRoom.Name = nameBox.Text;
                tempRoom.Description = descriptionBox.Text;
                tempRoom.Coordinates = new[] {latitude, longitude};
                tempRoom.Size = Convert.ToInt32(sizeBox.Text);
                //todo: add walls
                RoomRepository.Save(tempRoom);
            }

            App.Router.Route("MyRoomsView");

        }
    }
}
