using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
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
             Add(new Agent("007", "Nico", "", "Coding", "A"));
             Add(new Agent("001", "ANico", "", "Coding", "d"));
             Add(new Agent("006", "ZNico", "", "Coding", "z"));
        }

         private int _SelectedIndex = 0; // neat to have index out of code (easier to manipulate)


         private string _FilePath = "";

         public string FilePath
         {
             get => _FilePath;
             set
             {
                 _FilePath = value;
                 Notify("FilePath");
             }
         }


         public int SelectedIndex
         {
             get => _SelectedIndex;
             set
             {
                 _SelectedIndex = value;
                 Notify("SelectedIndex");
             }
         }

         private Agent _selectedAgent; //bruges til synkronisering af agenter der er sorteret.
         public Agent SelectedAgent
         {
             get => _selectedAgent;
             set
             {
                 _selectedAgent = value;
                 Notify();
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
                            () =>
                            {
                                Agent x = new Agent("New","new","","Coding","new");
                                SelectedAgent = x;
                                Add(x);
                                Notify();
                            },
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
                            () =>
                            {
                                Remove(SelectedAgent);
                            },
                            () => this.Count > 0));
             }
         }

        /* Persistance */
         private ICommand _NewCommand;

         public ICommand NewCommand
         {
             get
             {
                 return _NewCommand ?? (_NewCommand = new RelayCommand(
                                () =>
                                {
                                    Clear();
                                    FilePath = "";
                                },
                            () => true));
             }
         }

         private ICommand _OpenCommand;
        
         public ICommand OpenCommand
        {
             get
             {
                 return _OpenCommand ?? (_OpenCommand = new RelayCommand(
                                () =>
                                {

                                    try
                                    {
                                        
                                        using (Stream stream = File.Open(FilePath, FileMode.Open))
                                        {
                                            BinaryFormatter bin = new BinaryFormatter();

                                            var agents2 = (List<Agent>)bin.Deserialize(stream);
                                            Clear();
                                            foreach (Agent varAgent in agents2)
                                            {
                                                Add(varAgent);
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        MessageBox.Show("no files with the specified name!");
                                    }


                                },
                                () => FilePath != ""));
             }
         }

         private ICommand _SaveCommand;

         public ICommand SaveCommand
        {
             get
             {
                 return _SaveCommand ?? (_SaveCommand = new RelayCommand(
                            () =>
                            {
                                using (Stream stream = File.Open(FilePath, FileMode.Create))
                                {
                                    BinaryFormatter bin = new BinaryFormatter();
                                    bin.Serialize(stream, Items);
                                }
                            },
                            () => _FilePath != ""));
             }
         }

         //does nothing, only shows the usage of command parameters, since i moved filepath logic to this class
         private ICommand _SaveAsCommand;

         public ICommand SaveAsCommand
        {
             get
             {
                 return _SaveAsCommand ?? (_SaveAsCommand = new RelayCommand<string>(
                            p =>
                            {
                                FilePath = p;
                                SaveCommand.Execute(null);
                            },
                            p => true));
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
             if (value.All(char.IsDigit))
             {
                 id = value;
                 
                }
             else
             {
                 id = "";
                 throw new ApplicationException("Only numbers");
             }
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
