
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
    }
}
