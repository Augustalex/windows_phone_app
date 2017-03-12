using Windows.UI.Xaml.Media;

namespace Laboration_3.Models
{
    public class Wall
    {
        public int RoomId { get; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ImageSource Image { get; set; }
    }
}