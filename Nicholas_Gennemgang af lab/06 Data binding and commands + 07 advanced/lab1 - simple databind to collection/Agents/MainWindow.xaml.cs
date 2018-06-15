
using System.Windows;
using I4GUI;


namespace Agents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //instantiate single agent
        Agent Agents = new Agent("007","James Bond","","Killing","Kill the president");
        public MainWindow()
        {
            //enable binding from code behind
            DataContext = Agents;
            
            InitializeComponent();
        }
    }
}
