using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Agents.Annotations;
using Agents.Properties;
using MvvmFoundation.Wpf;

namespace Agents
{

    

    public class WindowColors : INotifyPropertyChanged
    {
        #region Notify

        public event PropertyChangedEventHandler PropertyChanged;
        protected void
            Notify([CallerMemberName]string propName = null
            )
        {
            var handler
                = PropertyChanged;
            if (handler != null)
            {
                handler(this
                    , new PropertyChangedEventArgs(propName));
            }
        }

        #endregion



        //standard color for the window

        private ICommand _NewBackgroundCommand;

        public ICommand NewBackgroundCommand
        {
            get
            {
                return _NewBackgroundCommand ?? (_NewBackgroundCommand = new RelayCommand<SolidColorBrush>(
                           c =>
                           {
                               App.Current.MainWindow.Resources["BackgroundColor"] = c;                              
                           },
                           c => true));
            }

        }
    }
}
