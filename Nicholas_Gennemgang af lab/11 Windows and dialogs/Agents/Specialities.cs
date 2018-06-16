using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agents
{
    public class Specialities : ObservableCollection<string>, INotifyPropertyChanged
    {
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

        public Specialities()
        {
            Add("Coding");
            Add("Arkitekture");
            Add("Design");
            Add("Lazy");
        }

    }

    
}
