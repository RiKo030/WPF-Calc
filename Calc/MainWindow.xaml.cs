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

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1 = 0;
        double num2 = 0;
        string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Content.ToString();
            if (TextValue.Text == "0")
            {
                TextValue.Text = num;
            }
            else
            {
                TextValue.Text += num;
            }
            if (operation == "")
            {
                num1 = Double.Parse(TextValue.Text);
            }
            else
            {
                num2 = Double.Parse(TextValue.Text);
                
            }
        }


        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            switch(operation)
            {
                case "+":
                        result = num1 + num2;
                        break;
                case "":
                    result = num1;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                case "x^y":
                    result = Pow(num1, (int)num2);
                    break;
                case "min":
                    result = Math.Min(num1, num2);
                    break;
                case "max":
                    result = Math.Max(num1, num2);
                    break;
                case "avg":
                    result = (num1 + num2) / 2;
                    break;

            }

            TextValue.Text = result.ToString();
            operation = "";
            num1 = result;
            num2 = 0;
        }

        private double Pow(double num1, int num2)
        {
            if (num2 == 0)
            {
                return 1;
            }

            return Pow(num1, num2 - 1) * num1;
        }

        private void btn_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            TextValue.Text = "";
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                num1 = 0;
            }
            else
            {
                num2 = 0;
            }
            TextValue.Text = "0";
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            operation = "";
            TextValue.Text = "0";
        }

        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            TextValue.Text = DropLastNumber(TextValue.Text);
            if (operation == "")
            {
                num1 = Double.Parse(TextValue.Text);
            }
            else
            {
                num2 = Double.Parse(TextValue.Text);
            }
        }

        private string DropLastNumber(string v)
        {
            if (v.Length == 1)
            {
                return "0";
            }
            else
            {
                v = v.Remove(v.Length - 1, 1);
                if (v[v.Length - 1] == ',')
                    v = v.Remove(v.Length - 1, 1);
                return v;
            }

        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                num1 = num1 * -1;
                TextValue.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * -1;
                TextValue.Text = num2.ToString();
            }
        }

        private void btn_coma_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                SetComma(num1);
            }
            else
            {
                SetComma(num2);
            }
        }

        private void SetComma(double num)
        {
            if (TextValue.Text.Contains(','))
                return;
            TextValue.Text += ',';
        }
    }
}
