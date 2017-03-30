using System;
using System.Collections.Generic;
using System.IO;
using Laboration_3.Models;
using Newtonsoft.Json;

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
            WriteToJsonFile();
        }

        public static void Remove(int id)
        {
            offlineStorage.Remove(id);
        }

        private static void WriteToJsonFile()
        {

            File.WriteAllText("database.json", JsonConvert.SerializeObject(offlineStorage));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText("database.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, offlineStorage);
            }

        }


        public static void ReadFromJsonFile()
        {
            //TextReader reader = null;
            //try
            //{
            //    using(var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //    {
            //        reader = new StreamReader(fs);
            //        var fileContents = reader.ReadToEnd();
            //        return JsonConvert.DeserializeObject<T>(fileContents);
            //    }
            //}
            //finally
            //{
            //    if (reader != null)
            //        reader.Dispose();
            //}

            // read file into a string and deserialize JSON to a type
            Dictionary<int, Room> storage = JsonConvert.DeserializeObject<Dictionary<int, Room>>(File.ReadAllText("database.json"));
            
            // deserialize JSON directly from a file
            using(StreamReader file = File.OpenText("database.json"))
            {
                 JsonSerializer serializer = new JsonSerializer();
                 Dictionary<int, Room> storage2 = (Dictionary<int, Room>)serializer.Deserialize(file, typeof(Dictionary<int, Room>));
            }

            offlineStorage = storage;
        }

    }
}
