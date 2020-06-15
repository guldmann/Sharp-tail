using System;
using System.ComponentModel;
using System.Windows.Media;

namespace ListBoxControl.Models
{
    public class RowItem : INotifyPropertyChanged
    {
        public string Text { get; set; }
        public Color FrontColor { get; set; }
        public Color BackColor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}