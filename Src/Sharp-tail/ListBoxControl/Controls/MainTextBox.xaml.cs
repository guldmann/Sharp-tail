using Common.Messages.Services;
using Common.Tail;
using ListBoxControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ListBoxControl.Controls
{
    public partial class MainTextBox : UserControl
    {
        ObservableCollection<RowItem> _rowItems;
        private readonly MessageService _messageService = MessageService.Instance;
        private Task _task;
        private Tail _tail;

        public MainTextBox()
        {
            InitializeComponent();
            _messageService.Subscribe<List<string>>(TailUpdateEvent);
        }

        private void TailUpdateEvent(List<string> items)
        {
            //TODO For now using static colors for testing;
            //TODO: Get colors and word to highlight from some where

            foreach (var item in items)
            {
                Dispatcher.BeginInvoke(
                    new Action(() => _rowItems.Add(
                        new RowItem
                        {
                            BackColor = Colors.Red,
                            FrontColor = Colors.Black,
                            Text = item
                        })));
            }
        }

        public void SetDataFile(string file)
        {
            _rowItems = new ObservableCollection<RowItem>();
            //TODO: For now using static coloring.
            // TODO: Get colors from some where
            foreach (var row in File.ReadAllLines(file))
            {
                if (row.Contains("Warning"))
                {
                    _rowItems.Add(new RowItem { BackColor = Colors.Red, FrontColor = Colors.Black, Text = row });
                }
                else
                {
                    _rowItems.Add(new RowItem { BackColor = Colors.White, FrontColor = Colors.Black, Text = row });
                }
            }
            listBox.ItemsSource = _rowItems;
            TailFile(file);
        }

        //  Cant get control sizing to really work,
        // temp solution is to set it here and invoke it from main form.
        public void SetSize(double w, double H)
        {
            listBox.Width = w;
            listBox.Height = H;
        }

        private void TailFile(string file)
        {
            _tail?.StopTailFile();

            _tail = new Tail(file);
            _task = new Task(() => _tail.TailFile());
            _task.Start();
        }
    }
}
