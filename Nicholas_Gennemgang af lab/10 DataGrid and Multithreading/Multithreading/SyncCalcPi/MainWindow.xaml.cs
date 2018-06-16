﻿using System;
using System.Collections.Generic;
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
            await Task.Run(() => CalcPi(numbers));
            //CalcPi((int.Parse(this.tbxDigits.Text)));

            // Update statusbar
            sbiStatus.Content = "Ready";
        }

        void CalcPi(int digits)
        {
            StringBuilder pi = new StringBuilder("3", digits + 2);

            // Show progress
            ShowProgress(pi.ToString(), digits, 0);

            if (digits > 0)
            {
                pi.Append(".");

                for (int i = 0; i < digits; i += 9)
                {
                    int nineDigits = NineDigitsOfPi.StartingAt(i + 1);
                    int digitCount = Math.Min(digits - i, 9);
                    string ds = string.Format("{0:D9}", nineDigits);
                    pi.Append(ds.Substring(0, digitCount));

                    // Show progress
                    ShowProgress(pi.ToString(), digits, i + digitCount);
                }
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
