using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.PointOfService;
using Windows.Media.Audio;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Automation;
using Laboration_3.Models;
using Newtonsoft.Json;

namespace Laboration_3
{
    public class RoomRepository
    {
        public static Dictionary<int, Room> offlineStorage = new Dictionary<int, Room>();
       
        //serialisera till json
        public RoomRepository()
        {
            //FetchFromFile();
        }

        public static Room Fetch(int id)
        {
            if (!offlineStorage.ContainsKey(id))
            {
                throw new Exception("No such room.");
            }

            return offlineStorage[id];
        }

        public static void Save(Room room)
        {
            offlineStorage.Add(room.Id, room);
        }

        public static void Remove(int id)
        {
            offlineStorage.Remove(id);
        }

        private void SaveToFile()
        {
            var storageJson = JsonConvert.SerializeObject(offlineStorage.ToString());
            File.WriteAllText("database.txt", storageJson);

        }

        private async void FetchFromFile()
        {
            //var s = new FileStream();
            //using (StreamReader sr = new StreamReader("~/database.txt"))
            //{
            //    var offlineStorage = JsonConvert.DeserializeObject<Dictionary<int, Room>>(sr.ReadToEnd());
            //}


        }
    }
}
