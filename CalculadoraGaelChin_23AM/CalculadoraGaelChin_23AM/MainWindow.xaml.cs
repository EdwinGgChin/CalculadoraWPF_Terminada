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

namespace CalculadoraGaelChin_23AM
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
        public void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                //MessageBox.Show("Un mensaje de click");
                string value = (string)button.Content;  //se obtiene el contenido
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleNumbers(value);
                }
                else if (value == "C/CE")
                {
                    if (Screen.Text.Length == 1)
                    {
                        Screen.Text = "";
                    }
                    else if (Screen.Text.Length >= 1)
                    {
                        Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);
                    }
                    else
                    {
                        Screen.Clear();
                    }
                }
                else if (value == "=")
                {
                    HandleEquals(Screen.Text);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }

        public bool IsNumber(string num)
        {
            return double.TryParse(num, out _);
        }

        //METODOS AUXILIARES
        private void HandleNumbers(string value)
        {
            if (string.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;   
            }
        }

        private bool IsOperator(string possibleOperator)
        {
            /*if (possibleOperator == "+" || possibleOperator == "-" || possibleOperator == "" || possibleOperator == "/")
            {
                return true;
            }
            return false; */

            return possibleOperator == "+" || possibleOperator == "-" || possibleOperator == "*" || possibleOperator == "/";
        }
        private void HandleOperat(string value)
        {
            if (!string.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text += value;
            }
        }

        private string FindOperator(string screenContent)
        {
            foreach (char c in screenContent)
            {
                if (IsOperator(c.ToString()))
                {
                    return c.ToString();
                }
            }
            return screenContent;
        }
        private void HandleEquals(string screenContent)
        {
            string op = FindOperator(screenContent);

            if (!String.IsNullOrEmpty(op))

                switch (op)
                {
                    case "+":
                        Screen.Text = Suma();
                        break;
                    case "-":
                        Screen.Text = Resta();
                        break;
                    case "/":
                        Screen.Text = Division();
                        break;
                    case "*":
                        Screen.Text = Multiplicar();
                        break;
                }
        }
        private string Suma()
        {
            string[] numbers = Screen.Text.Split("+");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 + n2, 12).ToString();
        }
        private string Resta()
        {
            string[] numbers = Screen.Text.Split("-");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 - n2, 12).ToString();
        }

        private string Multiplicar()
        {
            string[] numbers = Screen.Text.Split("*");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 * n2, 12).ToString();
        }
        private string Division()
        {
            string[] numbers = Screen.Text.Split("/");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 / n2, 12).ToString();
        }
    }
}

