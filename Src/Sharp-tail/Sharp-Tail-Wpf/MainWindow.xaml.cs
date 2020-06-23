using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sharp_Tail_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TabViewModel tvm;

        public MainWindow()
        {
            InitializeComponent();
            tvm = new TabViewModel();
            MainTabControl.ItemsSource = tvm.Tabs;

            tvm.Populate();

            Tester();
        }

        private void Tester()
        {
            string temp = "";
        }

        private void OpenFile_click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenFolder_click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CloseAllFiles_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadGroup_click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveOpenFilesAsGroup_click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CloseTab_click(object sender, MouseButtonEventArgs e)
        {
            var temp = MainTabControl.SelectedItem as TabItem;

            MainTabControl.Items.RemoveAt(MainTabControl.SelectedIndex);
        }

        private void CtrlCCopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CtrlCCopyCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RightClickCopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RightClickCopyCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}