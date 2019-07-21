﻿using Common.Messages.Services;
using Common.Models;
using Common.Tail;
using ListBoxControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

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

        public void SetDataFile(string file, List<ColorRule> colorRules)
        {
            if (file == null)
                return;
            _File = file;
            ColorRules = colorRules ?? new List<ColorRule>();
            _rowItems = new ObservableCollection<RowItem>();

            foreach (var row in File.ReadAllLines(file))
            {
                AddRow(row);
            }
            listBox.ItemsSource = _rowItems;
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

        public void UpdateColorRules(List<ColorRule> colorRules)
        {
            SetDataFile(_File, colorRules);
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
