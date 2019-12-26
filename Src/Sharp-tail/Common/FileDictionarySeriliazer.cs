using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Common
{
    public static class FileDictionarySeriliazer
    {
        private const string LastFiles = "lastOpenFiles.json";

        public static void Save(Dictionary<int, string> files)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(LastFiles))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, files);
                }
            }
        }

        public static Dictionary<int, string> Load()
        {
            if (File.Exists(LastFiles))
            {
                var jstring = File.ReadAllText(LastFiles);

                return JsonConvert.DeserializeObject<Dictionary<int,string>>(jstring);
            }
            return new Dictionary<int, string>();
        }
    }
}
