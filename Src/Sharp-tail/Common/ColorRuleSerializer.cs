using System.Collections.Generic;
using Common.Models;
using Newtonsoft.Json;
using System.IO;

namespace Common
{
    public static class ColorRuleSerializer
    {
        public static void Save(this List<ColorRule> colorRules)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter("colorSettings.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, colorRules);
                }
            }
        }

        public static List<ColorRule> Load()
        {
            if (File.Exists("colorSettings.json"))
            {
                var jstring = File.ReadAllText("colorSettings.json");

                return JsonConvert.DeserializeObject<List<ColorRule>>(jstring);
            }

            return null;
            //if (File.Exists("colorSettings.json"))
            //{
            //    JsonSerializer jsonSerializer = new JsonSerializer();
            //    using (StreamReader sr = new StreamReader("colorSettings.json"))
            //    {
            //        using (JsonReader reader = new JsonTextReader(sr))
            //        {
            //            return (List<ColorRule>) jsonSerializer.Deserialize(reader);
            //        }
            //    }
            //}
            //return null;
        }
    }
}
