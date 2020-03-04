using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Groups
    {
        public List<FileGroup> fileGroups { get; set; }
    }


    public class FileGroup
    {
        public string GroupName { get; set; }
        public List<TabFile> Tabfiles { get; set; }
    }
}
