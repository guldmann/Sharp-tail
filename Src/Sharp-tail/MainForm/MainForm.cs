﻿using System;
using System.IO;
using System.Windows.Forms;

namespace MainForm
{
    public partial class MainForm : Form
    {
        private FileInfo fInfo;
        private bool FullScreen = false;

        public MainForm()
        {
            InitializeComponent();
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
            mainTextBox1.SetDataFile(file);
            MainForm_Resize(this, null);
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
        }

        private void MainTextBox1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F11)
                ToogleFullScreen();
        }

        private void ToogleFullScreen()
        {
            if(FullScreen)
            {
                FullScreen = false;
                menuStrip1.Visible = true;
                statusStrip1.Visible = true;
                TopMost = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                FullScreen = true;
                menuStrip1.Visible = false;
                statusStrip1.Visible = false;
                TopMost = true;
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
    }
}
