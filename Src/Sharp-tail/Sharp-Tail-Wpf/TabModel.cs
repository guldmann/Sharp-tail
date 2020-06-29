using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Windows.Media;
using Common.Models;
using ListBoxControl.Controls;
using Sharp_Tail_Wpf.Annotations;

namespace Sharp_Tail_Wpf
{
    public class TabItemModel : INotifyPropertyChanged
    {
        public string HeaderText { get; set; }

        public TabContentModel Content { get; set; }

        public MainTextBox _DataBox { get; set; }
        //public LogView DataBox { get; set; }

        private Brush _headerColor = Brushes.Black;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Brush HeaderColor
        {
            get => _headerColor;
            set
            {
                _headerColor = value;
                OnPropertyChanged("HeaderColor");
            }
        }

        public MainTextBox DataBox
        {
            get => _DataBox;
            set
            {
                //DataBox = value;
                OnPropertyChanged("DataBox");
            }
        }


    }

    public class TabContentModel : INotifyPropertyChanged
    {
        public string TextString { get; set; }
        private Brush _fontColor = Brushes.Black;
        private Brush _backColor = Brushes.White;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Brush FontColor
        {
            get => _fontColor;
            set
            {
                _fontColor = value;
                OnPropertyChanged(nameof(FontColor));
            }
        }

        public Brush BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                OnPropertyChanged(nameof(BackColor));
            }
        }
    }

    public class TabContent
    {
    }

    public class TabViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public ObservableCollection<TabItemModel> Tabs { get; set; }

        public TabViewModel()
        {
            Tabs = new ObservableCollection<TabItemModel>();
        }

        public void Populate()
        {
            //var tabItem = new TabItemModel
            //{
            //    HeaderText = "Header 1 ",
            //    HeaderColor = Brushes.Blue,
            //    Content = new ObservableCollection<TabContentModel>()
            //};
            var content = new TabContentModel
            {
                BackColor = Brushes.Blue,
                FontColor = Brushes.Red,
                TextString = "this is row test"
            };
            //tabItem.AddRow(content);

            /////Temp test populating tabs
            //Tabs.Add(tabItem);

            var data = new MainTextBox();
            data.SetDataFile(@"C:\temp\rlog.log", new List<ColorRule>(), null, "test");
            data.SetSize(1000, 1000);
            data.ScrollToEnd();

            //var data = new LogView();

            Tabs.Add(new TabItemModel() { HeaderText = "TabHEader 2", HeaderColor = Brushes.Red, Content = new TabContentModel { BackColor = Brushes.LightPink, FontColor = Brushes.Crimson, TextString = "This is a TabContetntModel" }, _DataBox = data });
            var temp = "";
            Tabs.Add(new TabItemModel() { HeaderText = "TabHEader 3", HeaderColor = Brushes.Red, Content = new TabContentModel { BackColor = Brushes.LightPink, FontColor = Brushes.Crimson, TextString = "This is a TabContetntModel number 2" }, _DataBox = data });
            //Tabs.Add(new TabItemModel() { HeaderText = "TabHEader 3", HeaderColor = Brushes.GreenYellow, Content = "This is ConTent nr 3" });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}