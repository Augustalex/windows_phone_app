using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_3
{
    public class RoomRepository
    {
        Dictionary<int, Room> offlineStorage = new Dictionary<int, Room>();

        public Room Fetch(int id)
        {
            if (!offlineStorage.ContainsKey(id))
            {
                throw new Exception("No such room.");
            }

            return offlineStorage[id];
        }

        public void Save(Room room)
        {
            offlineStorage.Add(room.Id, room);
        }
    }
}
