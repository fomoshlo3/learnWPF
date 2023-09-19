using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserInputApp
{
    //TODO: Refactor to MVVM pattern  after completion

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Note: The ? after double declares that it's nullable. Null isn't the same as 0.
        //  It means that there's no value at all. Null is important because later, we check to see
        //  if the user entered a value in the first TextBox. We want to do the calculation
        //  if the user entered a 0 but not if the user left it empty.

        //Get or sets the value of the first number that the arithmetic will be performed on.
        private double? FirstNumber {  get; set; }
        private double? SecondNumber {  get; set; }

        //Get or sets the selected arithmetic operation.
        //Note: https://learn.microsoft.com/en-us/training/modules/create-ui-for-windows-10-apps/3-getting-user-input?pivots=wpf 
        private Func<double, double, double> SelectedMathFunction { get; set; }
        private double Add(double a, double b)
        {
            return a + b;
        }

        private double Subtract(double a, double b)
        {
            return a - b;
        }

        private double Multiply(double a, double b)
        {
            return a * b;
        }

        private double Divide(double a, double b)
        {
            return a / b;
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void FirstNumberBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //Check if the text in FirstNumberBox.Text is empty.
            if (string.IsNullOrEmpty(FirstNumberBox?.Text))
            {
                FirstNumber = null;
                return;
            }
            //If text was entered, check to see if it can be parsed into a number.
            if (double.TryParse(FirstNumberBox?.Text, out double parsedNumber))
            {
                //If the text is an integer, then set the value of the FirstNumber property
                FirstNumber = parsedNumber;
            }
            else
            {
                //If it is not a number, remove the last entered character with TrimEnd() method
                FirstNumberBox.Text = FirstNumberBox.Text.TrimEnd(FirstNumberBox.Text.LastOrDefault());
            }
        }

        // We can share one event handler for all the RadioButtons' Checked event, this prevents a lot of duplicate code.
        private void RadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            // We can use a single line of code to get the RadioButton reference.
            var radioButton = (RadioButton)sender;

            // Get the value of the RadioButton's Content (this contains the name of the math operation we want).
            string radioButtonContent = radioButton?.Content?.ToString();

            // Set the appropriate arithmetic operation to use by checking radioButtonContent's value.
            switch (radioButtonContent)
            {
                case "Add":
                    SelectedMathFunction = Add;
                    break;

                case "Subtract":
                    SelectedMathFunction = Subtract;
                    break;

                case "Multiply": 
                    SelectedMathFunction = Multiply;
                    break;

                case "Divide": 
                    SelectedMathFunction = Divide;
                    break;

                default: 
                    SelectedMathFunction = null;
                    break;
            }
        }

        private void SecondNumberBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SecondNumberBox?.Text))
            {
                SecondNumber = null;
                return;
            }

            if (double.TryParse(SecondNumberBox?.Text, out double parsedNumber))
            {
                SecondNumber = parsedNumber;
            }
            else
            {
                SecondNumberBox.Text = SecondNumberBox.Text.TrimEnd(SecondNumberBox.Text.LastOrDefault());
            }
        }

        private void SecondNumberSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // You would typically use e.NewValue to get the Slider's value as it changes.
            // However, the SecondTextBox.TextChanged event is already getting the value, we can just set the SecondNumberBox.Text instead.
            SecondNumberBox.Text = e.NewValue.ToString("N");
        }

        private void IncludeDateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // When the CheckBox is checked, show the DatePickers.
            CalculationDatePicker.Visibility = Visibility.Visible;
            CalculationDatePicker.SelectedDate = DateTime.Now;
        }

        private void IncludeDateCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // When the CheckBox is unchecked, hide the DatePickers.
            CalculationDatePicker.Visibility = Visibility.Collapsed;
        }

        private void EqualsButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Before doing any calculations, confirm the user entered both numbers.
            if (FirstNumber == null || SecondNumber == null)
            {
                MessageBox.Show("You need to set both numbers to calculate a result.");
                return;
            }

            // Now is a good time to do some validation on the numbers and prevent any serious problems.
            // For example, here we make sure the user isn't trying to divide from zero, this can crash your app!
            if (SecondNumber == 0 && SelectedMathFunction == Divide)
            {
                MessageBox.Show("You cannot divide from zero, please pick a different 2nd number.");
                return;
            }

            // Next, it's time to do the actual math. We only need to pass the two numbers into the SelectedMathFunction.
            double result = SelectedMathFunction((double)FirstNumber, (double)SecondNumber);

            // Finally, show the result to the user!
            if (IncludeDateCheckBox.IsChecked == true)
            {
                // If the CheckBox was checked, show the number with the "N2" string format (a number to 2 decimal points),
                // but also include the Date in the output with the "d" string format (a short date format).
                ResultsTextBlock.Text = $"Result: {result:N2}, Date: {CalculationDatePicker.SelectedDate:d}";
            }
            else
            {
                // If the CheckBox was not checked, show the number with the "N2" string format (a number to 2 decimal points).
                ResultsTextBlock.Text = $"Result: {result:N2}";
            }
        }
    }
}
