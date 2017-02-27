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

namespace MyCalculation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private double firstNum = 0.00;
        private string chosen = "";
        private double result = 0.00;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumClick(object sender, RoutedEventArgs e)
        {
            if (chosen == "=")
            {
                MessageBox.Show("请先输入运算符或清除键继续");
                return;
            }
            String str = ((Button)sender).Content.ToString();
            ChosenNum.Text += str;
            Formula.Text += str;
            
        }

        private void NumSignClick(object sender, RoutedEventArgs e)
        {
            if (chosen == "=")
            {
                MessageBox.Show("请先输入运算符或清除键继续");
                return;
            }
            if (ChosenNum.Text == "")
            {
                MessageBox.Show("请先输入数字！");
                return;
            }
            double temp = double.Parse(ChosenNum.Text);
            int length = Formula.Text.Length;
            int numLength = ChosenNum.Text.Length;
            ChosenNum.Text = (0 - temp).ToString();
            if (temp > 0)
            {
                Formula.Text = Formula.Text.Substring(0, length - numLength) + "(" + ChosenNum.Text + ")";
            }
            else
            {
                Formula.Text = Formula.Text.Substring(0, length - numLength - 2) + ChosenNum.Text;
            }
        }

        private void ResultClick(object sender, RoutedEventArgs e)
        {   
            if (chosen == "")
            {
                Answer.Text = ChosenNum.Text;
                return;
            }
            Answer.Text = OperationFunc(chosen).ToString();
            chosen = "=";
        }

        private void SignClick(object sender, RoutedEventArgs e)
        {
            String str = ((Button)sender).Content.ToString();
            if (ChosenNum.Text == "")
            {
                MessageBox.Show("请先输入数字！");
                return;
            }
            if (chosen == "")
            {
                firstNum = double.Parse(ChosenNum.Text);
                Formula.Text += str;
                ChosenNum.Text = "";
                chosen = str;
            }
            else if (chosen == "=")
            {
                firstNum = result;
                Formula.Text = result + str;
                ChosenNum.Text = "";
                chosen = str;
            }
            else
            {
                MessageBox.Show("请先点击=号结算结果！");
            }
            
        }

        private double OperationFunc(String opera)
        {
            try
            {   
                switch (opera)
                {
                    case "+":
                        result = firstNum + double.Parse(ChosenNum.Text);
                        break;
                    case "-":
                        result = firstNum - double.Parse(ChosenNum.Text);
                        break;
                    case "×":
                        result = firstNum * double.Parse(ChosenNum.Text);
                        break;
                    case "÷":
                        result = firstNum / double.Parse(ChosenNum.Text);
                        break;
                    default:
                        break;
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Operation! Maybe some bugs I forget to fix...");
                throw;
            }

            return result;
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            ChosenNum.Text = "";
            Formula.Text = "";
            Answer.Text = "";
            firstNum = 0.00;
            result = 0.00;
            chosen = "";
        }
    }
}
