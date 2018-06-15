
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
        //instantiate agents
        Agent Agent1 = new Agent("007","James Bond","","Killing","Kill the president");
        Agent Agent2 = new Agent("008", "Nicholas Ladefoged", "", "Being Epic", "Program WPF");
        //add collection for datacontext
        ObservableCollection<Agent> AgentCol = new ObservableCollection<Agent>();
        

        public MainWindow()
        {
            //enable binding from code behind
            DataContext = AgentCol;
            //add agents to the collection
            AgentCol.Add(Agent1);
            AgentCol.Add(Agent2);
            
            InitializeComponent();
        }
    }
}
