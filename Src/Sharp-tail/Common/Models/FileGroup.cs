using System.Collections.Generic;

namespace Common.Models
{
    public class Groups
    {
        public List<FileGroup> FileGroups { get; set; }
    }

    public class FileGroup
    {
        public string GroupName { get; set; }
        public List<TabFile> Tabfiles { get; set; }
    }
}