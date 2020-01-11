using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers;

namespace Common.Models
{
    public class TabFile
    {
        public string Name { get; set; }
        public string File { get; set; }
        private string _TabName { get; set; }

        public string TabName
        {
            get => _TabName.Truncate();
            set => _TabName = value.RemoveCross();
        }
    }
}
