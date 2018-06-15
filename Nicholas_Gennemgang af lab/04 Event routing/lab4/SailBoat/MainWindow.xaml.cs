using System;
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

namespace SailBoat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sailboat sailboatObj = new Sailboat();
        public MainWindow()
        {
            InitializeComponent();
            PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                if (e.Key == Key.L)
                {
                    this.FontSize += 2;
                }

                if (e.Key == Key.S)
                {
                    this.FontSize -= 2;
                }
            }
        }

        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            CalculatedText.Text = sailboatObj.Hullspeed().ToString();
        }

        private void NameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            sailboatObj.Name = NameTextBox.Text;
        }

        private void LengthTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (LengthTextBox.Text.Trim() != "" || !LengthTextBox.Text.Contains(" "))
            {
                try
                {
                    LengthTextBox.Text.Trim();
                    sailboatObj.Length = Convert.ToDouble(LengthTextBox.Text);
                }
                catch (Exception exception)
                {
                    
                    MessageBox.Show("Only put in numbers!!");
                    LengthTextBox.Clear();
                }
            }
            else
            {
                LengthTextBox.Clear();
            }
            

            
        }


        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sailboatObj.Name.Length > 0)
            {
                var x = MessageBox.Show("name of the boat is: " + sailboatObj.Name);

            }
        }
    }
}
