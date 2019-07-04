using System;
using System.IO;
using Newtonsoft.Json;

namespace TextBasedRpg.Data
{
    public static class SaveSystem
    {
        public static string Save(SaveData saveData)
        {
            string json = JsonConvert.SerializeObject(saveData);
            Console.WriteLine(json);
            File.WriteAllText("Data/save1.json", json);
            return json;
        }

        public static SaveData Load()
        {
            string json = File.ReadAllText("Data/save1.json");
            Console.WriteLine(json);
            return JsonConvert.DeserializeObject<SaveData>(json);
        }
    }
}