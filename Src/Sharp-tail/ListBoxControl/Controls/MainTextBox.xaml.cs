﻿using Common.Messages.Services;
using Common.Models;
using Common.Tail;
using ListBoxControl.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.AppCenter.Crashes;

namespace ListBoxControl.Controls
{
    public partial class MainTextBox : IDisposable
    {
        private ObservableCollection<RowItem> _rowItems;
        private  MessageService _messageService = MessageService.Instance;
        private Task _task;
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private readonly CancellationToken _token;
        private Tail _tail;
        private List<ColorRule> _colorRules = new List<ColorRule>();
        public string File;
        private bool _goToEnd = true;
        public bool Updated;
        private bool _evaluate = true;
        public static ILogger Logger;
        private bool _filterActive;
        public long FileSize;

        public MainTextBox()
        {
            InitializeComponent();
            _messageService.Subscribe<TaileFileInfo>(TailUpdateEvent);
            _token = _tokenSource.Token;
        }

        private void TailUpdateEvent(TaileFileInfo taileFileInfo)
        {
            if (taileFileInfo.Name == File)
            {
                _evaluate = false;
                Updated = true;
                int rows = 1;
                FileSize = taileFileInfo.Size;

                foreach (var item in taileFileInfo.FilesRows)
                {
                    if (rows >= taileFileInfo.FilesRows.Count)
                    {
                        if (Dispatcher != null)
                            Dispatcher.BeginInvoke(
                                new Action(() => AddRow(item, true)));
                    }
                    else
                    {
                        if (Dispatcher != null)
                            Dispatcher.BeginInvoke(
                                new Action(() => AddRow(item)));
                    }
                    rows++;
                }
            }
        }

        private void AddRow(string text, bool evaluate = false)
        {
            bool textWriten = false;
            if (_colorRules != null)
            {
                //Note first Color rule matching will apply
                foreach (var rule in _colorRules)
                {
                    if (CaseCompare(text, rule.Text, rule.Casesensitiv))
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
            }

            if (!textWriten)
            {
                _rowItems.Add(new RowItem { BackColor = Colors.White, FrontColor = Colors.Black, Text = text });
            }

            if (_goToEnd)
            {
                ScrollToEnd(text);
            }
            if (evaluate) _evaluate = true;
        }

        private bool CustomFilter(object obj)
        {
            if (!_filterActive) return true;

            var row = (RowItem)obj;

            if (_colorRules.Count >= 1)
            {
                foreach (var colorRule in _colorRules)
                {
                    if (CaseCompare(row.Text, colorRule.Text, colorRule.Casesensitiv))
                    {
                        return true;
                    }
                }

                return false;
            }
            return true;
        }

        public void SetDataFile(string file, List<ColorRule> colorRules, ILogger log, string tabName)
        {
            if (Logger == null) Logger = log;

            if (file == null)
                return;
            try
            {
                File = file;
                _colorRules = colorRules ?? new List<ColorRule>();

                _rowItems = new ObservableCollection<RowItem>();

                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader reader = new StreamReader(fs))
                {
                    FileSize = reader.BaseStream.Length;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        AddRow(line);
                    }
                    reader.Close();
                    fs.Close();
                    reader.Dispose();
                    fs.Dispose();
                }

                listBox.ItemsSource = null;
                listBox.ItemsSource = _rowItems;

                //Filterable collection
                if (CollectionViewSource.GetDefaultView(listBox.ItemsSource) is CollectionView view) view.Filter = CustomFilter;

                TailFile(file, tabName);
            }
            catch (Exception e)
            {
                CrachReport(e, file);
            }
        }



        private void CrachReport(Exception e, string extra)
        {
            StringBuilder sb = new StringBuilder();
            var values = new Dictionary<string, string>();
            
            foreach (var rule in _colorRules)
            {
                sb.Append(rule.ToJson()).Append("\n");
            }
            values.Add("Color_rules", sb.ToString());
            values.Add("Extra ", extra);
            values.Add("nuber off RowItems", _rowItems.Count.ToString());
            values.Add("Task", _task.Status.ToString());
            values.Add("GotToEnd", _goToEnd.ToString());
            values.Add("Updated", Updated.ToString());
            values.Add("Evaluate", _evaluate.ToString());
            values.Add("_filterActive", _filterActive.ToString());
            values.Add("FileSize", FileSize.ToString());

            Crashes.TrackError(e, values);
        }

        public void ScrollToEnd(string text = "")
        {
            //https://stackoverflow.com/questions/2006729/how-can-i-have-a-listbox-auto-scroll-when-a-new-item-is-added
            if (listBox.Items.Count > 1)
            {
                listBox.ScrollIntoView(_rowItems[_rowItems.Count - 1]);
                listBox.SelectedItem = _rowItems[_rowItems.Count - 1];
            }
        }

        // Cant get control sizing to really attach to main form.
        // temp solution is to set it here and invoke it from main form.
        // witch will force a redraw of text box and all is nice, cake , balloons and happy faces.
        public void SetSize(double w, double h)
        {
            listBox.Width = w;
            listBox.Height = h;
        }

        /// <summary>
        /// Toggle Filter on /off
        /// and refresh text view
        /// </summary>
        public void ActivateFilter()
        {
            _filterActive = !_filterActive;
            CollectionViewSource.GetDefaultView(_rowItems).Refresh();
        }

        private bool CaseCompare(string text, string value, bool caseSencetiv)
        {
            StringComparison stringComparison = StringComparison.CurrentCulture;
            if (!caseSencetiv)
            {
                stringComparison = StringComparison.CurrentCultureIgnoreCase;
                return text.IndexOf(value, stringComparison) >= 0;
            }

            return text.IndexOf(value, stringComparison) >= 0;
        }

        public void UpdateColorRules(List<ColorRule> colorRules, ILogger log)
        {
            if (Logger == null) Logger = log;
            Logger.Debug("Updateing Color rules");
            _colorRules = colorRules ?? new List<ColorRule>();
            int rows = _rowItems.Count;
            int index = 0;
            bool textWriten = false;

            while (index < rows)
            {
                if (colorRules != null)
                    foreach (var rule in colorRules)
                    {
                        if (CaseCompare(_rowItems[index].Text, rule.Text, rule.Casesensitiv))
                        {
                            _rowItems[index].BackColor = Color.FromRgb(
                                rule.Background.R,
                                rule.Background.G,
                                rule.Background.B);
                            _rowItems[index].FrontColor = Color.FromRgb(
                                rule.ForeGround.R,
                                rule.ForeGround.G,
                                rule.ForeGround.B);
                            textWriten = true;
                            break;
                        }
                    }

                if (!textWriten)
                {
                    _rowItems[index].BackColor = Colors.White;
                    _rowItems[index].FrontColor = Colors.Black;
                }
                textWriten = false;
                index++;
            }

            listBox.ItemsSource = null;
            listBox.ItemsSource = _rowItems;

            CollectionViewSource.GetDefaultView(_rowItems).Refresh();
        }

        private void TailFile(string file, string tabName)
        {
            _tail?.StopTailFile();
            _tail = new Tail(file, tabName);
            _task = new Task(() => _tail.TailFile(_token), _token);
            _task.Start();
        }

        public void listBox_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (!_evaluate) return;
            _goToEnd = e.ExtentHeight
                == (e.ViewportHeight + e.VerticalOffset)
                ? true
                : false;
        }

        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _rowItems.Clear();
                _rowItems = null;
                
                _tokenSource.Cancel();
                
                if (_task.IsCanceled || _task.IsCompleted)
                {
                    _task.Dispose();
                }
                _colorRules.Clear();
                _colorRules = null;
                listBox.ItemsSource = null;
                _messageService = null;
              _tail.Dispose();

            }

            disposed = true;
        }

        /// <summary>
        /// Copy marked row to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlCCopyCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox lb = (ListBox)(sender);
            var selected =(RowItem) lb.SelectedItem;
            if (selected != null) Clipboard.SetText(selected.Text);
        }

        private void CtrlCCopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //show right click copy menu
        private void RightClickCopyCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            var selected = (RowItem) mi.DataContext;
            if (selected != null) Clipboard.SetText(selected.Text);
        }

        private void RightClickCopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void FindExecute(object sender, ExecutedRoutedEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            var selected = (RowItem)mi.DataContext;
            if (selected != null) Clipboard.SetText(selected.Text);
        }
        private void FindCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        
    }
}