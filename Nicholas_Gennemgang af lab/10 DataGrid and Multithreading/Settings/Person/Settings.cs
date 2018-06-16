using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmFoundation.Wpf;

namespace Person
{


    public class Settings : INotifyPropertyChanged
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

        #region Properties

        public string name => Properties.Settings.Default.Name;



        public int age
        {
            get { return Properties.Settings.Default.Age; }
            set
            {
                Properties.Settings.Default.Age = value;
                Notify();
            }
        }

        #endregion

        #region Commands

        private ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new RelayCommand<string>(
                           p =>
                           {
                               age = Convert.ToInt32(p);
                               Properties.Settings.Default.Save();
                           },
                           p => true
                       ));
            }
        }

        private ICommand _resetCommand;

        public ICommand ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand = new RelayCommand(
                           () =>
                           {
                               Properties.Settings.Default.Reset();    

                               age = Properties.Settings.Default.Age;   //set model
                           },
                           () => true
                       ));
            }
        }


        private ICommand _rollBackCommand;

        public ICommand RollBackCommand
        {
            get
            {
                return _rollBackCommand ?? (_rollBackCommand = new RelayCommand(
                           () =>
                           {
                               Properties.Settings.Default.Reload();    //get previous

                               age = Properties.Settings.Default.Age;   //set model
                           },
                           () => true
                       ));
            }
        }

        #endregion


    }
}
