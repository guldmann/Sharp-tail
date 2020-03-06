using System.Collections.Generic;
using Common.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Common
{
    public static class FileGroupHandler
    {
        private const string GroupsFile = "FileGroup.json";
        private static readonly string Root = Application.StartupPath;

        public static void Save(Groups groups)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(Path.Combine(Root, GroupsFile)))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, groups);
                }
            }
        }

        public static Groups Load()
        {
            if (File.Exists(Path.Combine(Root, GroupsFile)))
            {
                var jstring = File.ReadAllText(Path.Combine(Root, GroupsFile));

                return JsonConvert.DeserializeObject<Groups>(jstring);
            }
            return new Groups
            {
              FileGroups  = new List<FileGroup>()
            };
        }

        public static FileGroup GetByName(this Groups groups, string name)
        { 
            return groups.FileGroups.FirstOrDefault(t => t.GroupName == name);
        }

        public static FileGroup GetByIndex(this Groups groups, int index)
        {
            return groups.FileGroups[index];
        }
    }
}