using Common;
using Common.Messages.Services;
using Common.Models;
using ListBoxControl.Controls;
using MainForm.Extension;
using Serilog;
using Serilog.Sink.AppCenter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using Common.Helpers;
using Microsoft.AppCenter.Crashes;
using DataFormats = System.Windows.Forms.DataFormats;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using DragEventArgs = System.Windows.Forms.DragEventArgs;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace MainForm
{
    public partial class MainForm : Form
    {
        private List<TabFile> _files = new List<TabFile>();
        private FileInfo _fInfo;
        private bool _fullScreen;
        private bool _ctrlDown;
        private List<ColorRule> _colorRules;
        private readonly MessageService _messageService = MessageService.Instance;
        public static ILogger Logger;
        private bool _filter;
        private Groups _groups;

        public MainForm(string[] args)
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

            MainForm_Resize(null, null);
            tabControl1.MouseClick += tabControl1_MouseClick;
            tabControl1.ShowToolTips = true;
            timer1.Enabled = true;
            if (args != null)
            {
                var tabFiles = new List<TabFile>();
                foreach (var file in args)
                {
                    tabFiles.Add(new TabFile
                    {
                        File = file,
                        Name = Guid.NewGuid().ToString(),
                        TabName = file
                    });
                }
                SetFile(tabFiles);
            }
            LoadPrevious();
            LoadGroups();
        }

        private void LoadGroups()
        {
            _groups = FileGroupHandler.Load();
        }

        /// <summary>
        /// Ask user to open previous files.
        /// </summary>
        private void LoadPrevious()
        {
            var files = FileDictionarySeriliazer.Load();
            if (files.Count <= 0) return;

            StringBuilder sb = new StringBuilder();
            sb.Append("Open previous opened files ?").Append("\n");
            foreach (var file in files)
            {
                sb.Append("* ").Append(file.File).Append("\n");
            }

            var result = MessageBox.Show(sb.ToString(), "Open previous files?", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) return;
            var tabFiles = new List<TabFile>();
            foreach (var file in files.Where(file => File.Exists(file.File)))
            {
                tabFiles.Add(file);
            }

            SetFile(tabFiles);
        }

        /// <summary>
        /// Select Tab under mouse pointer and show context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            for (var tab = 0; tab < tabControl1.TabCount; ++tab)
            {
                if (tabControl1.GetTabRect(tab).Contains(e.Location))
                {
                    tabControl1.SelectTab(tab);
                }
            }
            contextMenuStripTabs.Show(tabControl1, e.Location);
        }

        /// <summary>
        /// Find tab page by name from tail tabFile
        /// and call updatePage
        /// </summary>
        /// <param name="taileFileInfo"></param>
        private void TailUpdateEvent(TaileFileInfo taileFileInfo)
        {
            var page = tabControl1.TabPages[taileFileInfo.TabName];

            if (page.InvokeRequired)
            {
                page.Invoke(new EventHandler(delegate { page.Update(tabControl1); }));
            }
        }

        /// <summary>
        /// Call open tabFile dialog on behalf of tool strip menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        /// <summary>
        /// Open tabFile dialog. And if OK open tabFile.
        /// </summary>
        private void OpenFileDialog()
        {
            var result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;

            var tabFiles = openFileDialog1.FileNames
                .Select(fileName => new TabFile { File = fileName, Name = Guid.NewGuid().ToString(), TabName = fileName })
                .ToList();

            SetFile(tabFiles);
        }

        /// <summary>
        /// Set values to Tool strip
        /// </summary>
        /// <param name="name">Name of tabFile for current selected tab</param>
        /// <param name="size">Size of tabFile for current selected tab</param>
        private void SetFileAttributesToGui(string name, long size)
        {
            toolStripStatusLabelName.Text = "Name: " + name;
            toolStripStatusLabelSize.Text = "Size: " + (size / 1000) + "Kb";
        }

        /// <summary>
        /// Get fileInfo for passed files.
        /// set tool strip values.
        /// Calls to create tabs for passed files.
        /// </summary>
        /// <param name="files"></param>
        private void SetFile(List<TabFile> files)
        {
            foreach (var file in files)
            {
                _fInfo = new FileInfo(file.File);
                SetFileAttributesToGui(_fInfo.Name, _fInfo.Length);
                CreateTab(file);
            }
        }

        /// <summary>
        /// Create a tab page for passed tabFile.
        /// </summary>
        /// <param name="tabFile"></param>
        private void CreateTab(TabFile tabFile)
        {
            Log.Information("Creating tab for tabFile: " + tabFile);

            var tabPage = new TabPage(tabFile.TabName) { Width = 100 };

            var textbox = new MainTextBox
            {
                Name = "TextBox",
            };

            var host = new ElementHost
            {
                Name = "Host",
                Dock = DockStyle.Fill,
                Child = textbox
            };

            tabPage.ToolTipText = tabFile.File;
            tabPage.Name = tabFile.Name;// Guid.NewGuid().ToString();

            textbox.PreviewKeyDown += MainTextBox1_PreviewKeyDown;
            textbox.PreviewKeyUp += MainTextBox1_PreviewKeyUp;
            textbox.PreviewMouseWheel += MainTextBox1_MouseWheel;
            textbox.AllowDrop = true;
            textbox.Drop += MainTextBox1_Drop;
            textbox.DragEnter += MainTextBox1_DragEnter;
            textbox.SetDataFile(tabFile.File, _colorRules, Logger, tabPage.Name);

            tabPage.Controls.Add(host);
            tabControl1.TabPages.Add(tabPage);
            textbox.SetSize(host.Width, host.Height);
            textbox.ScrollToEnd();

            _files.Add(tabFile);

            tabControl1.SelectTab(tabPage);
        }

        /// <summary>
        /// Set tab-page content size when main form resizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //BUG: When windows display is set to scale above 100%, scrollbars in text view get buggy
            if (tabControl1.TabCount <= 0) return;

            var selected = tabControl1.SelectedIndex;
            var tab = tabControl1.TabPages[selected];

            var host = (ElementHost)tab.Controls[0];
            var textBox = (MainTextBox)host.Child;
            var with = textBox.ActualWidth;
            var height = textBox.ActualHeight;

            foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
            {
                host = (ElementHost)tabControl1TabPage.Controls[0];
                textBox = (MainTextBox)host.Child;
                textBox.SetSize(with, height);
            }
        }

        /// <summary>
        /// Drag tabFile in to main form event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Handle files dropped in main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var tabFiles = new List<TabFile>();

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                tabFiles.Add(new TabFile
                {
                    File = file,
                    Name = Guid.NewGuid().ToString(),
                    TabName = file
                });
            }
            SetFile(tabFiles);
        }

        /// <summary>
        /// Do resizing on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Resize(null, null);
        }

        /// <summary>
        /// This draws text "tabFile name" on tabs
        /// If Data in text box in tab page is updated and not selected it gives tab a green background
        ///
        /// if Tab is selected give it a darker gray
        ///
        /// NOTE: I think this is creating some flickering av tabs in GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tab = tabControl1.TabPages[e.Index];

            if (tab.Controls.Count <= 0) return;

            var host = (ElementHost)tab.Controls[0];
            var textBox = (MainTextBox)host.Child;

            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Height = 23;

            paddedBounds.Inflate(-2, -5);
            if (textBox.Updated)
            {
                if (tabControl1.SelectedIndex != e.Index)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightSeaGreen), e.Bounds);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText,
                        paddedBounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.Bounds);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText,
                        paddedBounds);
                }
            }
            else
            {
                if (tabControl1.SelectedIndex != e.Index)
                {
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText,
                        paddedBounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.Bounds);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText,
                        paddedBounds);
                }
            }
        }

        /// <summary>
        /// Zoom in/out on text if ctrl and mouse wheel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!_ctrlDown) return;

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

            if (direction >= 0 || tabControl1.TabCount <= 0) return;
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

        /// <summary>
        /// set that left ctrl is not pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox1_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
                _ctrlDown = false;
        }

        /// <summary>
        /// If key F11 Toggle full screen
        /// If key is plus zoom in on text
        /// If key is minus Zoom out on text
        /// If key is F Toggle text filter on / off
        /// if key is CTRL + S search for word in search text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F11)
                ToggleFullScreen();

            if (tabControl1.TabCount > 0)
            {
                if (e.Key == Key.OemPlus)
                {
                    foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
                    {
                        var host = (ElementHost)tabControl1TabPage.Controls[0];
                        var textBox = (MainTextBox)host.Child;
                        textBox.FontSize++;
                    }
                }

                if (e.Key == Key.OemMinus)
                {
                    foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
                    {
                        var host = (ElementHost)tabControl1TabPage.Controls[0];
                        var textBox = (MainTextBox)host.Child;
                        if (textBox.FontSize > 2)
                            textBox.FontSize--;
                    }
                }

                if (e.Key == Key.S)
                {
                    if (_ctrlDown) Search();
                }

                if (e.Key == Key.F)
                {
                    foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
                    {
                        var host = (ElementHost)tabControl1TabPage.Controls[0];
                        var textBox = (MainTextBox)host.Child;
                        textBox.ActivateFilter();
                    }

                    _filter = !_filter;
                    ChangeFilterGui();
                }
            }
            if (e.Key == Key.LeftCtrl)
                _ctrlDown = true;
        }

        private void Search()
        {
            if (toolStripTextBoxSearch.TextBox != null && !string.IsNullOrEmpty(toolStripTextBoxSearch.TextBox.Text))
            {
                if (tabControl1.SelectedIndex > -1)
                {
                    TabPage tabPage = tabControl1.TabPages[tabControl1.SelectedIndex];
                    if (tabPage.Controls.Count > 0)
                    {
                        var host = (ElementHost)tabPage.Controls[0];
                        var textBox = (MainTextBox)host.Child;
                        textBox.Search(toolStripTextBoxSearch.TextBox.Text);
                    }
                }
            }
        }

        /// <summary>
        /// Update Gui to show if filer is on or off.
        /// </summary>
        private void ChangeFilterGui()
        {
            if (_filter)
            {
                toolStripMenuItemFilter.Text = "Filter Active";
                toolStripMenuItemFilter.BackColor = Color.LightGreen;
            }
            else
            {
                toolStripMenuItemFilter.Text = " Filter Inactive";
                toolStripMenuItemFilter.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Make Gui text-box "Full screen"
        /// </summary>
        private void ToggleFullScreen()
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

        /// <summary>
        /// When tabFile drags in to main text-Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox1_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effects = System.Windows.DragDropEffects.Copy;
        }

        /// <summary>
        /// When files is dropped in main text-box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox1_Drop(object sender, System.Windows.DragEventArgs e)
        {
            var tabFiles = new List<TabFile>();

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                tabFiles.Add(new TabFile
                {
                    File = file,
                    Name = Guid.NewGuid().ToString(),
                    TabName = file
                });
            }
            SetFile(tabFiles);
        }

        /// <summary>
        /// Open color rule form and apply new rules to text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemColorRule_Click(object sender, EventArgs e)
        {
            ColorRulesForm cf = new ColorRulesForm(_colorRules);
            cf.StartPosition = FormStartPosition.CenterParent;
            cf.ShowDialog();
            // cf.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);
            var result = cf.DialogResult;

            if (result != DialogResult.OK) return;

            _colorRules = cf.ColorRules;
            tabControl1.UpdateTextBoxColorRule(_colorRules, Logger);
        }

        /// <summary>
        /// Only react on left mouse button click else return.
        /// Catch user clicking on tab if clicked position is where text [X] on tab
        /// Then clean out resources connected to tab and remove tab.
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            for (var i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 30, r.Top, 14, 23);

                if (!closeButton.Contains(e.Location)) continue;

                CloseRemoveTab(tabControl1.TabPages[i].Name);
                break;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > -1)
            {
                TabPage tabPage = tabControl1.TabPages[tabControl1.SelectedIndex];
                if (tabPage.Controls.Count > 0)
                {
                    var host = (ElementHost)tabPage.Controls[0];
                    var textBox = (MainTextBox)host.Child;
                    textBox.Updated = false;
                    SetFileAttributesToGui(textBox.File, textBox.FileSize);
                }
            }
        }

        /// <summary>
        /// Move to end of text-box select last row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileDictionarySeriliazer.Save(_files);
        }

        /// <summary>
        /// Action to close application from tool strip menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Close selected tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > -1)
            {
                var name = tabControl1.SelectedTab.Name;
                CloseRemoveTab(name);
            }
        }

        private void CloseRemoveTab(string name)
        {
            var page = tabControl1.TabPages[name];
            _files.Remove(_files.FirstOrDefault(x => x.Name == name));
            page.Clean();
            tabControl1.TabPages.Remove(page);
        }

        /// <summary>
        /// Close all tabs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _files = new List<TabFile>();
            foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
            {
                CloseRemoveTab(tabControl1TabPage.Name);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //tabControl1.TabPages.Clear();
        }

        /// <summary>
        /// Close all but this tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeAlButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                if (page.TabIndex != tabControl1.SelectedTab.TabIndex)
                {
                    CloseRemoveTab(page.Name);
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Close all open files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeAllFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeAlToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// Timer to update memory usage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Process proc = Process.GetCurrentProcess();
            toolStripStatusLabel1.Text = "Mem usage: " + (proc.PrivateMemorySize64 / 1000000) + "MB";
        }

        /// <summary>
        /// Filter On/Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemFilter_Click(object sender, EventArgs e)
        {
            foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
            {
                var host = (ElementHost)tabControl1TabPage.Controls[0];
                var textBox = (MainTextBox)host.Child;
                textBox.ActivateFilter();
            }

            _filter = !_filter;
            ChangeFilterGui();
        }

        /// <summary>
        /// Open form to change text on selected tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                if (page.TabIndex == tabControl1.SelectedTab.TabIndex)
                {
                    RenameTabForm rtf = new RenameTabForm(page);
                    rtf.StartPosition = FormStartPosition.CenterParent;

                    var result = rtf.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        page.Text = rtf.tabText;
                        _files.Find(x => x.Name == page.Name).TabName = rtf.tabText;
                    }
                    return;
                }
            }
        }

        private void saveOpenFilesAsGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var groupForm = new CreateGroupForm();
            groupForm.StartPosition = FormStartPosition.CenterParent;
            var result = groupForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                List<TabFile> tabFiles = new List<TabFile>();

                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    var tabfile = new TabFile
                    {
                        TabName = tabPage.Text,
                        File = tabPage.ToolTipText,
                        Name = tabPage.Name,
                    };
                    tabFiles.Add(tabfile);
                }

                var group = new FileGroup
                {
                    GroupName = groupForm.name,
                    Tabfiles = tabFiles
                };
                _groups.FileGroups.Add(group);

                FileGroupHandler.Save(_groups);
            }
        }

        private void loadGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lgf = new LoadGroupForm(_groups);
            var result = lgf.ShowDialog();
            if (result != DialogResult.OK) return;

            var selectedGroups = lgf.SelectedGroups;
            var cloaseDialog = MessageBox.Show("Close current open files?", "Close files ", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cloaseDialog == DialogResult.OK)
            {
                // TODO close all open files here.
            }

            // TODO: iterate selected groups and open files
        }
    }
}