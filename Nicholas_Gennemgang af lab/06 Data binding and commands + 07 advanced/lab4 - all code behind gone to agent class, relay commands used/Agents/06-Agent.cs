using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MvvmFoundation.Wpf;

namespace I4GUI
{
     public class Agents : ObservableCollection<Agent> , INotifyPropertyChanged 
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

        #region Class setup
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
                 Notify("SelectedIndex");
             }
         }


        #endregion


        #region Commands
        //without lambda Previous
         private ICommand _PreviousCommand;

         public ICommand PreviousCommand
         {
             get
             {
                 return _PreviousCommand ??
                        (_PreviousCommand = new RelayCommand(PreviousCommandExecute, PreviousCommandCanExecute));
             }
         }

         private bool PreviousCommandCanExecute()
         {
             if (SelectedIndex > 0)
             {
                 return true;
             }

             return false;
         }

         private void PreviousCommandExecute()
         {
            SelectedIndex--;
        }

         //with lambda Next
         private ICommand _NextCommand;

         public ICommand NextCommand
         {
             get
             {
                 return _NextCommand ?? (_NextCommand = new RelayCommand(
                            () => ++SelectedIndex,
                            () => SelectedIndex < this.Count -1
                        ));
             }
         }

        //with lambda AddAgent
         private ICommand _AddCommand;

         public ICommand AddCommand
         {
             get
             {
                 return _AddCommand ?? (_AddCommand = new RelayCommand(
                            () => Add(new Agent("new","new","new","new","new")),
                            () => true));
             }
         }

         //with lambda removeAgent
         private ICommand _RemoveCommand;

         public ICommand RemoveCommand
        {
             get
             {
                 return _RemoveCommand ?? (_RemoveCommand = new RelayCommand(
                            () => RemoveAt(SelectedIndex),
                            () => this.Count > 0));
             }
         }

        

        #endregion


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
