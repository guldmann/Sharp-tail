using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;
using Common.Models;
using Newtonsoft.Json;

namespace Common
{
    public static class FileDictionarySeriliazer
    {
       
        private const string LastFiles = "lastOpenFiles.json";
        private static readonly string Root = Application.StartupPath;

        public static void Save(List<TabFile> files)
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

        public static List<TabFile> Load()
        {
            if (File.Exists(Path.Combine(Root,LastFiles)))
            {
                var jstring = File.ReadAllText(Path.Combine(Root, LastFiles));

                return JsonConvert.DeserializeObject<List<TabFile>>(jstring);
            }
            return new List<TabFile>();
        }
    }
}
