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
            WriteFile("Data/save1.json", json);
            return json;
        }

        public static SaveData Load()
        {
            string json = ReadFile("Data/save1.json");
            Console.WriteLine(json);
            return JsonConvert.DeserializeObject<SaveData>(json);
        }

        private static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        private static void WriteFile(string fileName, string json)
        {
            File.WriteAllText(fileName, json);
        }
    }
}