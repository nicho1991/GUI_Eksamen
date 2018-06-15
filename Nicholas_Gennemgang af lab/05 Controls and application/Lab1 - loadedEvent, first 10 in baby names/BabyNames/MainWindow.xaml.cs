using System;
using System.Collections.Generic;
using System.IO;
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

namespace BabyNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Loaded += new RoutedEventHandler(MainWindow_OnLoaded);
        }

        private void MainWindow_OnLoaded(object sender, EventArgs e)
        {
            try
            {
                //use a reader to get text from txt file
                StreamReader sr = new StreamReader("BabyNames.txt");

                for (int i = 0; i < 10; i++)
                {
                    //read one line at a time
                    var CurrentLine = sr.ReadLine();
                    //add the line to listbox
                    MainLSTDecadeTopNames.Items.Add(CurrentLine);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error loading text file, put BabyNames.txt in \"bin/debug/\"");
            }
           



           
        }
    }
}
