
using System.Collections.ObjectModel;
using System.Windows;
using I4GUI;


namespace Agents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //using resources to access the collection
        private I4GUI.Agents agents;
        public MainWindow()
        {
            InitializeComponent();

            agents = (I4GUI.Agents)this.Resources["Agents"];
        }



        private void AddClick(object sender, RoutedEventArgs e)
        {
            Agent newAgent = new Agent("new","new","","new","new");


           agents.Add(newAgent);

        }

        private void ForwardClick(object sender, RoutedEventArgs e)
        {
            if (agents.SelectedIndex < MainListBoxAgents.Items.Count -1)
            {
                agents.SelectedIndex++;
            }
            
        }

        private void PreviousClick(object sender, RoutedEventArgs e)
        {
            if (agents.SelectedIndex > 0)
            {
                agents.SelectedIndex--;
            }

        }
    }
}
