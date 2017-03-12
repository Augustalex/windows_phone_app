using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Laboration_3.Views
{
    public class EditRoomViewModel
    {
        public EditRoomViewModel()
        {
            RoomId = -1;
        }

        public EditRoomViewModel(int id)
        {
            RoomId = id;
        }

        public int RoomId { get; }

        public string RoomName { get; set; }

        public string RoomDescription { get; set; }

        public int RoomSize { get; set; }
    
        public Geoposition RoomCoords { get; set; }

        public bool PageHasRoomId()
        {
            return RoomId != -1;
        }
    }
}
