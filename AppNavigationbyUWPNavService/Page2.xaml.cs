using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AppNavigationbyUWPNavService
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2(object parameter = null)
        {
            InitializeComponent();

            if (parameter is string textMessage)
            {
                // If the parameter is a string, set the TextBlock's text with it.
                ParameterDataTextBlock.Text = textMessage;
            }
            else if (parameter is int numericalMessage)
            {
                // If the parameter is a number, show that number in the TextBlock.
                ParameterDataTextBlock.Text = $"You sent the number {numericalMessage} as a navigation parameter.";
            }
            else
            {
                // If the parameter is null or any unexpected object type, use a generic welcome message.
                ParameterDataTextBlock.Text = "Welcome to Page 2, no parameters were passed.";
            }
        }

        private void GoBackButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Checking to make sure there is a page to go back to.
            if (NavigationService.CanGoBack)
            {
                // Programmatically navigate to the previous page.
                NavigationService.GoBack();
            }
        }
    }
}
