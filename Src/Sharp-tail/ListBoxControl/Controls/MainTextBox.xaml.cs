using Common.Messages.Services;
using Common.Models;
using Common.Tail;
using ListBoxControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Serilog;

namespace ListBoxControl.Controls
{
    public partial class MainTextBox : UserControl
    {
        ObservableCollection<RowItem> _rowItems;
        private readonly MessageService _messageService = MessageService.Instance;

        private Task _task;
        private Tail _tail;
        private List<ColorRule> ColorRules = new List<ColorRule>();
        private string _File;
        private bool GoToEnd = true;
        public bool Updated = false;
        private bool Evaluate = true;
        public static ILogger Logger;

        public MainTextBox()
        {
            InitializeComponent();
            _messageService.Subscribe<TaileFileInfo>(TailUpdateEvent);
        }

        private void TailUpdateEvent(TaileFileInfo taileFileInfo)
        {
            if (taileFileInfo.Name == _File)
            {
                Evaluate = false;
                Updated = true;
                int rows = 1;


                foreach (var item in taileFileInfo.FilesRows)
                {
                    if(rows >= taileFileInfo.FilesRows.Count)
                    {
                        Dispatcher.BeginInvoke(
                        new Action(() => AddRow(item,true)));
                    }
                    else
                    {
                        Dispatcher.BeginInvoke(
                       new Action(() => AddRow(item, false)));
                    }
                    rows++;
                }

            }
        }

        private void AddRow(string text, bool evaluate = false)
        {
            //Note first rule matching will apply
            bool textWriten = false;

            foreach (var rule in ColorRules)
            {
                if (text.Contains(rule.Text))
                {
                    _rowItems.Add(new RowItem
                    {
                        BackColor = Color.FromRgb(
                            rule.Background.R,
                            rule.Background.G,
                            rule.Background.B),
                        FrontColor = Color.FromRgb(
                            rule.ForeGround.R,
                            rule.ForeGround.G,
                            rule.ForeGround.B),
                        Text = text
                    });
                    textWriten = true;
                    break;
                }
            }
            if (!textWriten)
            {
                _rowItems.Add(new RowItem { BackColor = Colors.White, FrontColor = Colors.Black, Text = text });
            }

            if (GoToEnd)
            {
                ScrollToEnd(text);
            }
            if (evaluate) Evaluate = true;
        }

        public void SetDataFile(string file, List<ColorRule> colorRules, ILogger log)
        {
            if(Logger == null) Logger = log;

            if (file == null)
                return;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            _File = file;
            ColorRules = colorRules ?? new List<ColorRule>();
            _rowItems = new ObservableCollection<RowItem>();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            watch.Stop();
            Logger.Debug("New colour rule and collection Time: " + watch.ElapsedMilliseconds + "ms");

            Stopwatch watchRows = new Stopwatch();
            watchRows.Start();
            
            FileStream fs = new FileStream(file, FileMode.Open,FileAccess.Read ,FileShare.ReadWrite);
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(fs))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    AddRow(line);
                }   
            }


            watchRows.Stop();
            Logger.Debug("Adding rows " + file + " Time: " + watchRows.ElapsedMilliseconds + "ms");

            Stopwatch watchItemsSource = new Stopwatch();
            watchItemsSource.Start();
            listBox.ItemsSource = null;
            listBox.ItemsSource = _rowItems;
            watchItemsSource.Stop();
            Logger.Debug("Item source Time: " + watchItemsSource.ElapsedMilliseconds + "ms");
                
            TailFile(file);
        }

        public void ScrollToEnd(string text = "")
        {
            //https://stackoverflow.com/questions/2006729/how-can-i-have-a-listbox-auto-scroll-when-a-new-item-is-added
            if (listBox.Items.Count > 1)
            {
                listBox.ScrollIntoView(_rowItems[_rowItems.Count-1]);
                listBox.SelectedItem = _rowItems[_rowItems.Count-1];
            }
        }

        // Cant get control sizing to really attach to main form.
        // temp solution is to set it here and invoke it from main form.
        // witch will force a redraw of text box and all is nice, cake , balloons and happy faces.
        public void SetSize(double w, double H)
        {
            listBox.Width = w;
            listBox.Height = H;
        }

        public void UpdateColorRules(List<ColorRule> colorRules, ILogger log)
        {
            if (Logger == null) Logger = log;
            Logger.Debug("Updateing Color rules");
            SetDataFile(_File, colorRules, log);
        }

        private void TailFile(string file)
        {
            //TODO: Evaluate this !!
            // This is from when only one instance of this was on main form.
            // Now a new instance is created for every new file opened in a new tab
            // TODO: delete code not needed.
            _tail?.StopTailFile();

            _tail = new Tail(file);
            _task = new Task(() => _tail.TailFile());
            _task.Start();
        }

        public void listBox_ScrollChanged(object sender , ScrollChangedEventArgs e)
        {
            if (!Evaluate) return;
            GoToEnd = e.ExtentHeight 
                == (e.ViewportHeight + e.VerticalOffset) 
                ? true 
                : false;
        }
    }
}
