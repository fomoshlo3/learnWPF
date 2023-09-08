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

namespace CodeBehindVs2022.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// One would write behavioral logic here, but it's also POSSIBLE to design the
        /// application's GUI from within.
        /// The code-behind gives one the possibility to dynamically add elements or controls. 
        /// In practice it would be done within a resource library.
        /// The button doesn't invoke behavior, will be covered in later tutorials.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Create the Stackpanel
            StackPanel stackPanel = new StackPanel();
            this.Content = stackPanel;

            //Create the TextBlock
            TextBlock textBlockGreeting = new TextBlock()
            {
                Text = "Willkomen beim XAMl Anfängerkurs.",
                Height = 20,
                Width = 210,
                Margin = new Thickness(5),
            };

            //Create the Button
            Button btnApprove = new Button()
            {
                Content = "OK",
                Height = 20,
                Width = 50,
                Margin = new Thickness(5)
            };

            //Adding to the Children collection of the Stackpanel
            stackPanel.Children.Add(textBlockGreeting);
            stackPanel.Children.Add(btnApprove);

        }
    }
}