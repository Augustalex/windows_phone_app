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
        string filePath = "database.csv";

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

        private static void WriteToJsonFile<T>(string filePath, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(offlineStorage);
                using (var fs = new FileStream("database.txt", FileMode.Open, FileAccess.Read))
                {
                    writer = new StreamWriter(fs);
                    writer.Write(contentsToWriteToFile);
                }

            }
            finally
            {
                if (writer != null)
                    writer.Flush();
                writer.Dispose();
            }
        }

        private static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                using(var fs = new FileStream("database.txt", FileMode.Open, FileAccess.Read))
                {
                    reader = new StreamReader(fs);
                    var fileContents = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(fileContents);
                }
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }
    }
}
