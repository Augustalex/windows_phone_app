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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Laboration_3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditRoomView : Page
    {
        public EditRoomView()
        {
            this.InitializeComponent();

        }

        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.Route("MainPage");
        }

        private async void GetCoordsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Geoposition coords = await App.Geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                );

                coordinatesBlock.Text = coords.Coordinate.Point.Position.Latitude.ToString("0.00") + " " +
                                        coords.Coordinate.Point.Position.Longitude.ToString("0.00");
            }

            catch (Exception ex)
            {
                coordinatesBlock.Text = "location disabled.";
            }
            
        }

        private void WallEditorBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.Route("WallEditor");
        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var name = nameBox.Text;
            var description = descriptionBox.Text;
            var size = Convert.ToInt32(sizeBox.Text);
        }

    }
}
