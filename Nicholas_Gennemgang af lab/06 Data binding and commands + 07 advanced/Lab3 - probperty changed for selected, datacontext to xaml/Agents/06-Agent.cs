using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace I4GUI
{
     public class Agents : ObservableCollection<Agent> , INotifyPropertyChanged
     {
        #region Notifier
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

        public Agents() : base()
        {
            Add(new Agent("007", "James Bond", "", "Killing", "Kill the president"));
            Add(new Agent("008", "Nicholas Ladefoged", "", "Being Epic", "Program WPF"));
        }

         private int _SelectedIndex = 0; // neat to have index out of code (easier to manipulate)
         public int SelectedIndex
         {
             get => _SelectedIndex;
             set
             {
                 _SelectedIndex = value;
                 Notify();
             }
         }

     }   




   [Serializable]
   public class Agent
   {
      string id;
      string codeName;
      string speciality;
      string assignment;

      public Agent()
      {
          
      }

      public Agent(string aId, string aName, string aAddress, string aSpeciality, string aAssignment)
      {
         id = aId;
         codeName = aName;
         speciality = aSpeciality;
         assignment = aAssignment;
      }

      public string ID
      {
         get
         {
            return id;
         }
         set
         {
            id = value;
         }
      }

      public string CodeName
      {
         get
         {
            return codeName;
         }
         set
         {
            codeName = value;
         }
      }

      public string Speciality
      {
         get
         {
            return speciality;
         }
         set
         {
            speciality = value;
         }
      }

      public string Assignment
      {
         get
         {
            return assignment;
         }
         set
         {
            assignment = value;
         }
      }
   }
}
