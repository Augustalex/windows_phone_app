using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Laboration_3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WallEditor : Page
    {
        private int roomId;
        private WallViewModel wallViewModel;
        private Dictionary<string, object> dependencies = new Dictionary<string, object>();

        public WallEditor()
        {
            this.roomId = wallViewModel.RoomId;
            this.InitializeComponent();
        }
        private WallViewModel GetContext()
        {
            if (this.dependencies.ContainsKey("context"))
            {
                return dependencies["context"] as WallViewModel;
            }
            else
            {
                return new WallViewModel(roomId);
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.dependencies = e.Parameter as Dictionary<string, object>;
            wallViewModel = GetContext();
        }

        private async void UpdateView()
        {
            nameBlock.Text = wallViewModel.Title;
            descriptionBox.Text = wallViewModel.Description;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                imagePreview.Source = new BitmapImage(new Uri(file.Path));
            }
        }

        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.Router.RevertToCheckpoint();
        }

        private async void SaveImageToFile(StorageFile photo)
        {
            if (photo != null)
            {
                StorageFolder destinationFolder = 
                    await ApplicationData.Current.LocalFolder.CreateFolderAsync("WallImages", CreationCollisionOption.OpenIfExists);

                // Approriately saving the picture file with the room title and current room SurfaceSide
                // for identification later.

                var roomId = wallViewModel.RoomId;

                await photo.CopyAsync(destinationFolder, wallViewModel.Title + "_" + roomId, NameCollisionOption.ReplaceExisting);
                //await savedPhoto.DeleteAsync();
                photo = null;
            }
        }

        private async void CameraBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo == null)
            {
                // User cancelled photo capture
                return;
            }
            BitmapImage img = new BitmapImage(new Uri(photo.Path));
            wallViewModel.ImageUrl = photo.Path;
            SaveImageToFile(photo);
            imagePreview.Source = img;
        }

        private void ImageViewer_OnDragLeave(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var tempRoom = RoomRepository.offlineStorage[roomId];
            RoomRepository.offlineStorage.Remove(roomId);

            switch (wallViewModel.WallId)
            {
                case 0:
                    tempRoom.NorthWall.ImageUrl = wallViewModel.ImageUrl;
                    break;
                case 1:
                    tempRoom.EastWall.ImageUrl = wallViewModel.ImageUrl;
                    break;
                case 2:
                    tempRoom.SouthWall.ImageUrl = wallViewModel.ImageUrl;
                    break;
                case 3:
                    tempRoom.WestWall.ImageUrl = wallViewModel.ImageUrl;
                    break;
                case 4:
                    tempRoom.Floor.ImageUrl = wallViewModel.ImageUrl;
                    break;
                case 5:
                    tempRoom.Roof.ImageUrl = wallViewModel.ImageUrl;
                    break;
                default:
                    Debug.Write("Invalid ID");
                    break;
            }
        }
    }
}
