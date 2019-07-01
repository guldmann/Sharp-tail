using Common.Messages.Services;
using Common.Models;
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
        private List<ColorRule> ColorRules = new List<ColorRule>();
        private string _File;

        public MainTextBox()
        {
            InitializeComponent();
            _messageService.Subscribe<List<string>>(TailUpdateEvent);
        }

        private void TailUpdateEvent(List<string> items)
        {
            foreach (var item in items)
            {
                Dispatcher.BeginInvoke(
                    new Action(() =>AddRow(item)));
            }
        }

        private void AddRow(string text)
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
        }

        public void SetDataFile(string file, List<ColorRule> colorRules)
        {
            if (file == null)
                return;
            _File = file;
            ColorRules = colorRules ?? new List<ColorRule>();
            _rowItems = new ObservableCollection<RowItem>();

            using (var reader =
                new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    AddRow(line);
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

        public void UpdateColorRules(List<ColorRule> colorRules)
        {
            SetDataFile(_File, colorRules);
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
