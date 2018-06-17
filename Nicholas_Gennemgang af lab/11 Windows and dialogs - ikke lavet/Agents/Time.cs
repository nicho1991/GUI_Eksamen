using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace AgentsTime
{
    public class Time : INotifyPropertyChanged
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

        private static Timer x;
        private string _DateTime;

        public Time()
        {
            x = new Timer(1000);
            x.Interval = 1000;
            x.Elapsed += SetDate;
            x.Enabled = true;
        }

        private void SetDate(object sender, ElapsedEventArgs e)
        {
            DateTime = System.DateTime.Now.ToString("F");
        }

        

        public string DateTime
        {
            get => _DateTime;
            set
            {
                if (value != _DateTime)
                {
                    
                    _DateTime = value;
                    Notify();
                }
            }
        }
    }
}
