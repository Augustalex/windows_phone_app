using System;
using System.Collections.Generic;
using System.IO;
using Laboration_3.Models;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
using Windows.Storage;

namespace Laboration_3
{
    [Serializable]
    public class RoomRepository
    {
        public static Dictionary<int, Room> offlineStorage = new Dictionary<int, Room>();
        private static string filePath = "database.txt";

        
        public RoomRepository()
        {
            
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
            WriteToJsonFileAsync();
        }

        public static void Remove(int id)
        {
            offlineStorage.Remove(id);
        }

        private static async System.Threading.Tasks.Task WriteToJsonFileAsync()
        {
            string json = JsonConvert.SerializeObject(offlineStorage, Formatting.Indented);
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.GetFileAsync("database.json");
            await FileIO.WriteTextAsync(file, json);

        }


        public static async System.Threading.Tasks.Task ReadFromJsonFileAsync()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            if (localFolder.TryGetItemAsync("database.json") == null)
            {
                StorageFile file = await localFolder.CreateFileAsync("database.json");
                Dictionary<int, Room> storage = JsonConvert.DeserializeObject<Dictionary<int, Room>>(file.Path);
                offlineStorage = storage;
            }
            else
            {
                StorageFile file = await localFolder.GetFileAsync("database.json");
                // read file into a string and deserialize JSON to a type
                Dictionary<int, Room> storage = JsonConvert.DeserializeObject<Dictionary<int, Room>>(File.ReadAllText(file.Path));
                offlineStorage = storage;
            }

        }

    }
}
