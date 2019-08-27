using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Common;
using Common.Messages.Services;
using Common.Models;
using ListBoxControl.Controls;
using Serilog;
using Serilog.Sink.AppCenter;
using DataFormats = System.Windows.Forms.DataFormats;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using DragEventArgs = System.Windows.Forms.DragEventArgs;
using Point = System.Windows.Point;
using Microsoft.AppCenter;

namespace MainForm
{
    public partial class MainForm : Form
    {
        private const string CloseCross = "    [X]   ";
        private Dictionary<string, string> _files = new Dictionary<string, string>();
        private FileInfo _fInfo;
        private bool _fullScreen;
        private bool _ctrlDown;
        private List<ColorRule> _colorRules;
        private readonly MessageService _messageService = MessageService.Instance;
        public static ILogger Logger;


        public MainForm()
        {
            InitializeComponent();

            Logger = new LoggerConfiguration()
                .WriteTo.RollingFile("Logs\\log-{Date}.log")
                .WriteTo.AppCenterSink()
                .MinimumLevel.Debug()
                .CreateLogger();

            _colorRules = ColorRuleSerializer.Load();
            _messageService.Subscribe<TaileFileInfo>(TailUpdateEvent);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            var files = FileDictionarySeriliazer.Load();
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    //TODO:  Validate if file exist or try catch here
                    SetFile(new [] {file.Value});
                }
            }
            MainForm_Resize(null,null);
            tabControl1.MouseClick += new MouseEventHandler(tabControl1_MouseClick);
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            //selects the tab under the mouse pointer and then show context menu
            if (e.Button == MouseButtons.Right)
            {
                for (int tab = 0; tab < tabControl1.TabCount; ++tab)
                {
                    if (tabControl1.GetTabRect(tab).Contains(e.Location))
                    {
                        tabControl1.SelectTab(tab);
                    }
                }
                contextMenuStripTabs.Show(tabControl1, e.Location);
            }
        }

        private void TailUpdateEvent(TaileFileInfo taileFileInfo)
        {
            int index = taileFileInfo.Name.LastIndexOf("\\") + 1;
            var name = taileFileInfo.Name.Substring(index) + CloseCross;
            foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
            {
                if (tabControl1TabPage.Text == name && tabControl1TabPage.InvokeRequired)
                {
                    tabControl1TabPage.Invoke(new EventHandler(delegate { UpdatePage(tabControl1TabPage); }));
                }
            }
        }

        private void UpdatePage(TabPage page)
        {
            if (!page.Focused)
            {
                var host = (ElementHost) page.Controls[0];
                var textBox = (MainTextBox) host.Child;
                textBox.Updated = true;
            }

            page.Refresh();
            tabControl1.Refresh();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        private void OpenFileDialog()
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                SetFile(openFileDialog1.FileNames);
            }
        }

        private void SetFileAtrubutesToGui()
        {
            // Note: this is no  good,
            // Do we want this information ?
            // then do we want it as per file or for every file combined ?
            //toolStripStatusLabelName.Text = "Name: " + _fInfo.Name;
            //toolStripStatusLabelSize.Text = "Size: " + (_fInfo.Length / 1000) + "Kb";
        }

        private void SetFile(string[] files)
        {
            foreach (var file in files)
            {
                _fInfo = new FileInfo(file);
                SetFileAtrubutesToGui();
                CreateTab(file);
            }
        }

        private void CreateTab(string file)
        {
            //TODO: Set focus to last added TAB !
            Log.Information("Creating tab for file: " +file );
	        int lastIndex = file.LastIndexOf('\\');
	        var tabPage = new TabPage(file.Substring(lastIndex+1) + CloseCross);
            tabPage.Width = 100;

	        var textbox = new MainTextBox
	        {
		        Name = "TextBox",
	        };

			var host = new ElementHost
			{
				Name="Host",
				Dock=DockStyle.Fill,
				Child=textbox
			};

            tabPage.Name = Guid.NewGuid().ToString();

            textbox.PreviewKeyDown += MainTextBox1_PreviewKeyDown;
            textbox.PreviewKeyUp += MainTextBox1_PreviewKeyUp;
            textbox.PreviewMouseWheel += MainTextBox1_MouseWheel;
            textbox.AllowDrop = true;
            textbox.Drop += MainTextBox1_Drop;
            textbox.DragEnter += MainTextBox1_DragEnter;
            textbox.SetDataFile(file, _colorRules, Logger);
			tabPage.Controls.Add(host);
			tabControl1.TabPages.Add(tabPage);
			textbox.SetSize(host.Width, host.Height);
            textbox.ScrollToEnd();
            _files.Add(tabPage.Name, file);
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            //BUG: When windows display is set to scale above 100%, scrollbars in text view get buggy
            if (tabControl1.TabCount > 0)
            {
                int selected = tabControl1.SelectedIndex;
                TabPage tab = tabControl1.TabPages[selected];

                var host = (ElementHost) tab.Controls[0];
                var textBox = (MainTextBox) host.Child;
                double with = textBox.ActualWidth;
                double height = textBox.ActualHeight;

                foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
                {
                    host = (ElementHost) tabControl1TabPage.Controls[0];
                    textBox = (MainTextBox) host.Child;
                    textBox.SetSize(with, height);
                }
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            SetFile(files);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Resize(null,null);
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tab = tabControl1.TabPages[e.Index];

            var host = (ElementHost) tab.Controls[0];
            var textBox = (MainTextBox) host.Child;

            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            if (textBox.Updated)
            {
                if (tabControl1.SelectedIndex != e.Index)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightPink), e.Bounds);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText,
                        paddedBounds);
                }
                else
                {
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText,
                        paddedBounds);
                }
            }
            else
            {
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText,
                    paddedBounds);
            }
        }

        private void MainTextBox1_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (_ctrlDown)
            {
                var direction = Math.Sign(e.Delta);
                if (direction > 0 && tabControl1.TabCount > 0)
                {
                    foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
                    {
                        var host = (ElementHost)tabControl1TabPage.Controls[0];
                        var textBox = (MainTextBox)host.Child;
                        textBox.FontSize++;
                    }
                }
                if (direction < 0 && tabControl1.TabCount > 0)
                {
                    foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
                    {
                        var host = (ElementHost)tabControl1TabPage.Controls[0];
                        var textBox = (MainTextBox)host.Child;
                        if (textBox.FontSize > 2)
                            textBox.FontSize--;
                    }
                }
            }
        }

        private void MainTextBox1_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.LeftCtrl)
                _ctrlDown = false;
        }

        private void MainTextBox1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F11)
                ToogleFullScreen();

            if (tabControl1.TabCount > 0)
            {
                if (e.Key == System.Windows.Input.Key.OemPlus)
                {
                    foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
                    {
                        var host = (ElementHost) tabControl1TabPage.Controls[0];
                        var textBox = (MainTextBox) host.Child;
                        textBox.FontSize++;
                    }
                }

                if (e.Key == System.Windows.Input.Key.OemMinus)
                {
                    foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
                    {
                        var host = (ElementHost)tabControl1TabPage.Controls[0];
                        var textBox = (MainTextBox)host.Child;
                        if (textBox.FontSize > 2)
                            textBox.FontSize--;
                    }
                }
            }
            if (e.Key == System.Windows.Input.Key.LeftCtrl)
                _ctrlDown = true;
        }

        private void ToogleFullScreen()
        {
            if (_fullScreen)
            {
                _fullScreen = false;
                menuStrip1.Visible = true;
                statusStrip1.Visible = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                _fullScreen = true;
                menuStrip1.Visible = false;
                statusStrip1.Visible = false;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void MainTextBox1_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effects = System.Windows.DragDropEffects.Copy;
        }

        private void MainTextBox1_Drop(object sender, System.Windows.DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            SetFile(files);
        }

        private void toolStripMenuItemColorRule_Click(object sender, EventArgs e)
        {

            ColorRulesForm cf = new ColorRulesForm(_colorRules);
            cf.ShowDialog();
            cf.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);
            var result = cf.DialogResult;
            if (result == DialogResult.OK)
            {
                _colorRules = cf.ColorRules;
				UpdateTextBoxColorRule();
            }
        }

        private void UpdateTextBoxColorRule()
        {
	        foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
	        {
		        var host = (ElementHost) tabControl1TabPage.Controls[0];
		        var textBox = (MainTextBox) host.Child;
				textBox.UpdateColorRules(_colorRules, Logger);
	        }
		}

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //Catch clicking [X] in tabs
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 30, r.Top, 14, 20);
                if (closeButton.Contains(e.Location))
                {
                    _files.Remove(tabControl1.TabPages[i].Name);
                    tabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > -1)
            {
                TabPage tabControl1TabPage = tabControl1.TabPages[tabControl1.SelectedIndex];
                var host = (ElementHost) tabControl1TabPage.Controls[0];
                var textBox = (MainTextBox) host.Child;
                textBox.Updated = false;
            }
        }

        private void goToEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > -1)
            {
                TabPage tabControl1TabPage = tabControl1.TabPages[tabControl1.SelectedIndex];
                var host = (ElementHost)tabControl1TabPage.Controls[0];
                var textBox = (MainTextBox)host.Child;
                textBox.ScrollToEnd();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileDictionarySeriliazer.Save(_files);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > -1)
            {
                _files.Remove(tabControl1.TabPages[tabControl1.SelectedTab.TabIndex].Name);
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void closeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
        }

        private void closeAlButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
	        foreach (TabPage page in tabControl1.TabPages)
	        {
		        if (page.TabIndex != tabControl1.SelectedTab.TabIndex)
		        {
			        _files.Remove(page.Name);
			        tabControl1.TabPages.Remove(page);
					page.Dispose();
				}
	        }

        }
    }
}
