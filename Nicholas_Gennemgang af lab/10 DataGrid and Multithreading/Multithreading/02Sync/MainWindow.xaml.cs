using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalcPiAlgoritm;

namespace SyncCalcPi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void miFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            // Update statusbar
            sbiStatus.Content = "Calculating...";

            // Convert control's decimal Value to an integer

            int numbers = int.Parse(tbxDigits.Text);


            //make use of background worker


            System.ComponentModel.BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DoWork;

            worker.RunWorkerCompleted += Compledted;

            worker.RunWorkerAsync(numbers);


            // Update statusbar
            sbiStatus.Content = "Ready";
        }

        private void Compledted(object sender, RunWorkerCompletedEventArgs e)
        {
            //update ui once completed
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            //get number 
            int number =  (int) e.Argument;
            //run all workers here

            CalcPi(number);

        }

        void CalcPi(int digits)
        {
            StringBuilder pi = new StringBuilder("3", digits + 2);

            // Show progress
            ShowProgress(pi.ToString(), digits, 0);

            if (digits > 0)
            {
                pi.Append(".");

                Parallel.For(0, digits/9, i =>
                {
                    int nineDigits = NineDigitsOfPi.StartingAt(i*9 + 1);
                    int digitCount = Math.Min(digits - i*9, 9);
                    string ds = string.Format("{0:D9}", nineDigits);
                    pi.Append(ds.Substring(0, digitCount));

                    // Show progress
                    ShowProgress(pi.ToString(), digits, i*9 + digitCount);
                });

            }
        }

        void ShowProgress(string pi, int totalDigits, int digitsSoFar)
        {
            // Display progress in UI
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tblkResults.Text = pi;
                progressBar.Maximum = totalDigits;
                progressBar.Value = digitsSoFar;
                progressBar.Visibility = Visibility.Visible;
            }));
           


            if (digitsSoFar == totalDigits)
            {
                // Reset UI

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    sbiStatus.Content = "Ready";
                    progressBar.Visibility = Visibility.Hidden;
                }));

            }
        }

    }
}
