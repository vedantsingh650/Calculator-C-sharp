
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator SelectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            

            acButton.Click += AcButton_Click;
            negButton.Click += NegButton_Click;
            equalButton.Click += EqualButton_Click;
          
        }


        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                //PreviousLabel.Content = $"{PreviousLabel.Content.ToString()}{newNumber.ToString()}";
                switch (SelectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = Calculate.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Sustraction:
                        result = Calculate.Sustraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = Calculate.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = Calculate.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }

        }


        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
                PreviousLabel.Content = $"{PreviousLabel.Content}{(sender as Button).Content.ToString()}";

            }

            if (sender == plusButton)
                SelectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                SelectedOperator = SelectedOperator.Sustraction;
            if (sender == multiButton)
                SelectedOperator = SelectedOperator.Multiplication;
            if (sender == divButton)
                SelectedOperator = SelectedOperator.Division;

        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
     
        }


        private void NegButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void PercButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }



        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = 0; result = 0;
            resultLabel.Content = "0";
            PreviousLabel.Content = "";
        }

  
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString()); 


            if (resultLabel.Content.ToString() == "0")
            {
                PreviousLabel.Content = $"{PreviousLabel.Content}{selectedValue}";
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                PreviousLabel.Content = $"{PreviousLabel.Content}{selectedValue}";
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }


    public enum SelectedOperator
    {
        Addition,
        Sustraction,
        Multiplication,
        Division
    }


    public class Calculate  
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Sustraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
             if(n2 == 0)
            {
                MessageBox.Show("Division by 0 is not possible", "Mathmatically Not Define", MessageBoxButton.OK, MessageBoxImage.Error);
               
                return 0;
            }

            return n1 / n2;
        }
    }



}
