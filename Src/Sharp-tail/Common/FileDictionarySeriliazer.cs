using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Common
{
    public static class FileDictionarySeriliazer
    {
       
        private const string LastFiles = "lastOpenFiles.json";
        private static readonly string Root = Application.StartupPath;

        public static void Save(Dictionary<string, string> files)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(Path.Combine(Root,LastFiles)))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, files);
                }
            }
        }

        public static Dictionary<string, string> Load()
        {
            if (File.Exists(Path.Combine(Root,LastFiles)))
            {
                var jstring = File.ReadAllText(Path.Combine(Root, LastFiles));

                return JsonConvert.DeserializeObject<Dictionary<string,string>>(jstring);
            }
            return new Dictionary<string, string>();
        }
    }
}
