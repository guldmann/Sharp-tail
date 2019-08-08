using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class TaileFileInfo
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public List<string> FilesRows = new List<string>();
    }
}
