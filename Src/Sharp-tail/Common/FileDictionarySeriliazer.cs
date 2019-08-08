using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Common
{
    public static class FileDictionarySeriliazer
    {
        public static void Save(Dictionary<string, string> files)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter("lastOpenFiles.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, files);
                }
            }
        }

        public static Dictionary<string, string> Load()
        {
            if (File.Exists("lastOpenFiles.json"))
            {
                var jstring = File.ReadAllText("lastOpenFiles.json");

                return JsonConvert.DeserializeObject<Dictionary<string,string>>(jstring);
            }
            return new Dictionary<string, string>();
        }
    }
}
