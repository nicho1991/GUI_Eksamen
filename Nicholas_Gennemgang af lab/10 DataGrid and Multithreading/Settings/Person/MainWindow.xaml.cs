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

namespace Person
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Age = Convert.ToInt32(MainAgeBox.Text);
           int x=  Properties.Settings.Default.Age;
            Properties.Settings.Default.Save();
        }

        private void RollClick(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reload();

            Properties.Settings.Default.Save();
        }

        private void DefaultClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
