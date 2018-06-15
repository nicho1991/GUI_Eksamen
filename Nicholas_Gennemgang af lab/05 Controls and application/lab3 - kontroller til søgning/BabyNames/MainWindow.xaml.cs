using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

        ObservableCollection<BabyName> babies = new ObservableCollection<BabyName>();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_OnLoaded);
            //handler for when user presses a decade
            MainLSTDecadeSelect.SelectionChanged += new SelectionChangedEventHandler(DecadeSelect_ChangedDecade);
            MainNameToSearch.TextChanged += new TextChangedEventHandler(NameChangedEvent);
            MainSearchButton.Click += new RoutedEventHandler(SearchClick);
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            var name = MainNameToSearch.Text;
            try
            {
                //try to find the baby
                var theBaby = babies.First(x => x.Name == name);
                MainAverageRankingBox.Text = theBaby.AverageRank().ToString();
                MainTrendBox.Text = theBaby.Trend().ToString();

                for (int i = 1900; i <= 2000; i+= 10)
                {
                    MainSearchRankingList.Items.Add(i + "\t" + theBaby.Rank(i));
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("No baby named: " + name);
                MainNameToSearch.Text = "";
                
            }


        }

        private void NameChangedEvent(object sender, TextChangedEventArgs e)
        {
            if (!MainNameToSearch.Text.All(char.IsLetter))
            {
                MessageBox.Show("Only letters");
                MainNameToSearch.Text = "";
            }
        }

        private void DecadeSelect_ChangedDecade(object sender, SelectionChangedEventArgs e)
        {
            MainLSTDecadeTopNames.Items.Clear();

            int year = Convert.ToInt32(MainLSTDecadeSelect.SelectedItem.ToString());
            var orderedBabies = babies.OrderByDescending(x => x.Rank(year)).AsEnumerable();

            for (int i = 0; i < 10; i++)
            {
                MainLSTDecadeTopNames.Items.Add(i+1 + ". " + orderedBabies.ElementAt(i).Name + " Ranked: " + orderedBabies.ElementAt(i).Rank(year));
            }  
        }

        private void MainWindow_OnLoaded(object sender, EventArgs e)
        {
            try
            {
                //use a reader to get text from txt file
                StreamReader sr = new StreamReader("BabyNames.txt");

                while (!sr.EndOfStream)
                {
                    //read one line at a time
                    var CurrentLine = sr.ReadLine();
                    //make new baby
                    BabyName currentBaby = new BabyName(CurrentLine);
                    //add to list
                    babies.Add(currentBaby);
                }
                //shows the total loaded babies
                MainLSTDecadeTopNames.Items.Add("total: " + babies.Count + " Babies");

                //add decade selections
                for (int i = 1900; i <= 2000; i+= 10)
                {
                    MainLSTDecadeSelect.Items.Add(i);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error loading text file, put BabyNames.txt in \"bin/debug/\"");
            }
           



           
        }


    }
}
