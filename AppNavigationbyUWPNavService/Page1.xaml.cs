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

namespace AppNavigationbyUWPNavService
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Page2Button_OnClick(object sender, RoutedEventArgs e)
        {
            // You can pass an object to the next page by using the Page2's constructor overload.
            if (SendTextDataRadioButton.IsChecked == true)
            {
                // Here we pass a string parameter.
                NavigationService?.Navigate(new Page2("You sent text data to Page 2!"));
            }
            else if (SendNumericalDataRadioButton.IsChecked == true)
            {
                // Here we pass an integer parameter.
                NavigationService?.Navigate(new Page2(5));
            }
            else if (SendNoDataRadioButton.IsChecked == true)
            {
                // Navigate without a parameter.
                NavigationService?.Navigate(new Page2());
            }
        }
    }
}
