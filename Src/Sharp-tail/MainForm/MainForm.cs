using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Common;
using Common.Models;
using ListBoxControl.Controls;
using DataFormats = System.Windows.Forms.DataFormats;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using DragEventArgs = System.Windows.Forms.DragEventArgs;
using Point = System.Windows.Point;

namespace MainForm
{
    public partial class MainForm : Form
    {
		//TabClose Icon 
		private System.Drawing.Point _ImageLocation = new System.Drawing.Point(19, 5);
		private System.Drawing.Point _imageHitArea = new System.Drawing.Point(19,2);
		Image CloseImage;


        private FileInfo fInfo;
        private bool FullScreen = false;
        private bool ctrlDown = false;
        private List<ColorRule> ColorRules;
        private Dictionary<string, string> tabpages;

        public MainForm()
        {
            InitializeComponent();
            ColorRules = ColorRuleSerializer.Load();
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
                SetFile(openFileDialog1.FileName);
            }
        }

        private void SetFileAtrubutesToGui()
        {
            toolStripStatusLabelName.Text = "Name: " + fInfo.Name;
            toolStripStatusLabelSize.Text = "Size: " + (fInfo.Length / 1000) + "Kb";
        }

        private void SetFile(string file)
        {
            fInfo = new FileInfo(file);
            SetFileAtrubutesToGui();
			CreateTab(file);

            //mainTextBox1.SetDataFile(file, ColorRules);
            //MainForm_Resize(this, null);
        }

        private void CreateTab(string file)
        {
	        
	        int lastIndex = file.LastIndexOf('\\');
	        var tabpageName = new TabPage(file.Substring(lastIndex+1));
	        var textbox = new MainTextBox
	        {
		        Name = "TextBox"
	        };
	        
			var host = new ElementHost
			{
				Name="Host",
				Dock=DockStyle.Fill,
				Child=textbox
			};

			textbox.SetDataFile(file, ColorRules);
			tabpageName.Controls.Add(host);
			tabControl1.TabPages.Add(tabpageName);
			textbox.SetSize(textbox.ActualWidth, textbox.ActualHeight);
			//TabControl1_DrawItem(this ,null);
			//var test = tabControl1.TabPages[0].Controls.Find("TextBox", true);
			////var test1 = (ElementHost)tabControl1.TabPages[0].Controls.Find("Host", true);
			//var test1 = (ElementHost) tabControl1.TabPages[0].Controls[0];
			//var tBox = (MainTextBox)test1.Child;
			//tBox.Name = "Gurka";

        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            mainTextBox1.SetSize(mainTextBox1.ActualWidth, mainTextBox1.ActualHeight);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            SetFile(files[0]);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainTextBox1.AllowDrop = true;
            mainTextBox1.Drop += MainTextBox1_Drop;
            mainTextBox1.DragEnter += MainTextBox1_DragEnter;
            mainTextBox1.PreviewKeyDown += MainTextBox1_PreviewKeyDown;
            mainTextBox1.PreviewKeyUp += MainTextBox1_PreviewKeyUp;
            mainTextBox1.PreviewMouseWheel += MainTextBox1_MouseWheel;

			//TODO: if this work make code parmanet Tab controle stuff 
			tabControl1.DrawMode=TabDrawMode.OwnerDrawFixed;
			tabControl1.DrawItem+=TabControl1_DrawItem;
			CloseImage = Properties.Resources.close;
			//Look in to this if image is wrong 
			tabControl1.Padding = new System.Drawing.Point(20,5);

        }

		private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
		{
			try
			{
				Image img = new Bitmap(CloseImage);
				
				Rectangle r = e.Bounds;
				r = tabControl1.GetTabRect(e.Index);
				r.Offset(2,2);
				Brush titleBrush = new SolidBrush(Color.Black);
				Font font = Font;
				string title = tabControl1.TabPages[e.Index].Text;

				e.Graphics.DrawString(title, font, titleBrush, new PointF(r.X, r.Y));

				var point = new System.Drawing.Point(r.X+(tabControl1.GetTabRect(e.Index).Width-_ImageLocation.X), _ImageLocation.Y);
					
				if (tabControl1.SelectedIndex >= 1)
				{
					e.Graphics.DrawImage(img, point);
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}
		}

		private void MainTextBox1_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
			//TODO: adjust this to Tabcontrole
            if (ctrlDown)
            {
                var direction = Math.Sign(e.Delta);
                if (direction > 0)
                {
                    mainTextBox1.FontSize++;
                }
                if (direction < 0)
                {
                    if (mainTextBox1.FontSize > 2)
                        mainTextBox1.FontSize--;
                }
            }
        }

        private void MainTextBox1_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.LeftCtrl)
                ctrlDown = false;
        }

        private void MainTextBox1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F11)
                ToogleFullScreen();
            if (e.Key == System.Windows.Input.Key.OemPlus)
                mainTextBox1.FontSize++;

            if (e.Key == System.Windows.Input.Key.OemMinus)
            {
                if (mainTextBox1.FontSize > 2)
                    mainTextBox1.FontSize--;
            }

            if (e.Key == System.Windows.Input.Key.LeftCtrl)
                ctrlDown = true;
        }

        private void ToogleFullScreen()
        {
            if (FullScreen)
            {
                FullScreen = false;
                menuStrip1.Visible = true;
                statusStrip1.Visible = true;
                //  TopMost = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                FullScreen = true;
                menuStrip1.Visible = false;
                statusStrip1.Visible = false;
                //TopMost = true;
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
            SetFile(files[0]);
        }

        private void mainTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void toolStripMenuItemColorRule_Click(object sender, EventArgs e)
        {

            ColorRulesForm cf = new ColorRulesForm(ColorRules);
            cf.ShowDialog();
            var result = cf.DialogResult;
            if (result == DialogResult.OK)
            {
                ColorRules = cf.ColorRules;
                //mainTextBox1.UpdateColorRules(ColorRules);
				UpdateTextBoxColorRule();
            }
        }

        private void UpdateTextBoxColorRule()
        {
	        foreach (TabPage tabControl1TabPage in tabControl1.TabPages)
	        {
		        var host = (ElementHost) tabControl1TabPage.Controls[0];
		        var textBox = (MainTextBox) host.Child;
				textBox.UpdateColorRules(ColorRules);
	        }
		}
    }
}
