using Windows.Devices.Geolocation;

namespace Laboration_3.Models
{
    public class Room
    {
        public int Id { get; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public int Size { get; set; }

        public Geoposition Coordinates { get; set; }

        public Wall NorthWall { get; set; }

        public Wall SouthWall { get; set; }

        public Wall WestWall { get; set; }

        public Wall EastWall { get; set; }

        public Wall Roof { get; set; }

        public Wall Floor { get; set; }
    }
}