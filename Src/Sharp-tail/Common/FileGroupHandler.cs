using Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Common
{
    public static class FileGroupHandler
    {
        private const string GroupsFile = "FileGroup.json";
        private static readonly string Root = Application.StartupPath;

        public static void Save(List<Groups> files)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(Path.Combine(Root, GroupsFile)))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, files);
                }
            }
        }

        public static List<Groups> Load()
        {
            if (File.Exists(Path.Combine(Root, GroupsFile)))
            {
                var jstring = File.ReadAllText(Path.Combine(Root, GroupsFile));

                return JsonConvert.DeserializeObject<List<Groups>>(jstring);
            }
            return new List<Groups>();
        }

        public static FileGroup GetByName(this List<Groups> groups, string name)
        {
            // return groups.FirstOrDefault(p => p.fileGroups).fileGroups.FirstOrDefault(p => p.GroupName == name);
        }

        //public static void Add(this List<Groups> groups)
        //{
        //    groups.
        //}
    }
}