using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Person
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            if (Person.Properties.Settings.Default.CallUpgrade)
            {
                Person.Properties.Settings.Default.Upgrade();
                Person.Properties.Settings.Default.CallUpgrade = false;
                Person.Properties.Settings.Default.Save();
            }
        }
    }
}
