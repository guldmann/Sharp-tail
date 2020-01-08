using System.Collections.Generic;
using Common.Models;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Common
{
    public static class ColorRuleSerializer
    {
        private static readonly string Root = Application.StartupPath;
        private const string FileName = "colorSettings.json";

        public static void Save(this List<ColorRule> colorRules)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(Path.Combine(Root, FileName)))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, colorRules);
                }
            }
        }

        public static List<ColorRule> Load()
        {
            if (File.Exists(Path.Combine(Root, FileName)))
            {
                var jstring = File.ReadAllText(Path.Combine(Root, FileName));

                return JsonConvert.DeserializeObject<List<ColorRule>>(jstring);
            }
            return null;
        }
    }
}
