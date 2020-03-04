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
