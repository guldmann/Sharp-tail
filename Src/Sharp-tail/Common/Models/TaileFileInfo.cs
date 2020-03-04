using System.Collections.Generic;

namespace Common.Models
{
    public class TaileFileInfo
    {
        public string Name { get; set; }
        public string TabName { get; set; }
        public long Size { get; set; }
        public List<string> FilesRows = new List<string>();
    }
}
