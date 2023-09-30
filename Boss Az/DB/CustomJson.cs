using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Boss_Az.DB
{
    internal static class CustomJson
    {
        public static string Dir = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\");

        public static void Save<T>(T? data, string file)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string filePath = Path.Combine(Dir, file + ".json");

            File.WriteAllText(filePath, JsonSerializer.Serialize(data, options));
        }

        public static T? Load<T>(string file) where T : new()
        {
            T? loadedData = new T();
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string filePath = Path.Combine(Dir, file + ".json");

            using FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);

            if (stream.Length != 0)
            {
                loadedData = JsonSerializer.Deserialize<T>(stream, options);
            }

            return loadedData;
        }
    }

}
