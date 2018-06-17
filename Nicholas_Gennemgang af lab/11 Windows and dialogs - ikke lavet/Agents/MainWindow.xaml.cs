
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using I4GUI;


namespace Agents
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

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox) sender;

            ComboBoxItem cbi = (ComboBoxItem) cb.SelectedItem;


            string newSortOrder;
            if (cbi != null)
            {
                if (cbi.Tag == null)
                    newSortOrder = "None";
                else
                    newSortOrder = cbi.Tag.ToString();

                SortDescription sortDesc = new SortDescription(newSortOrder, ListSortDirection.Ascending);
                ICollectionView cv = CollectionViewSource.GetDefaultView(cbi.DataContext);
                if (cv != null)
                {
                    cv.SortDescriptions.Clear();
                    if (newSortOrder != "None")
                        cv.SortDescriptions.Add(sortDesc);
                }
            }


        }

        private void Selector_OnSelectionChangedFilter(object sender, SelectionChangedEventArgs e)
        {


            ComboBox cb = (ComboBox) sender; // finder comboboxen

            string filter = (string) cb.SelectedItem; //selected item er en string, da den er bound til en collection


            ICollectionView cv = CollectionViewSource.GetDefaultView(cb.DataContext); // find view source objectet


            cv.Filter = o =>
            {
                Agent
                    x = o as Agent; // filter VIL have det er et object, så har brugt denne metode til at fremprovokere agent derfra

                return x.Speciality.Contains(filter);
            };

        }


        private void NoFilterClick(object sender, RoutedEventArgs e)
        {
            var x = sender as Button;

            ICollectionView cv = CollectionViewSource.GetDefaultView(x.DataContext); // find view source objectet
            cv.Refresh();

            cv.Filter = o => { return true; };
        }
    }
}
