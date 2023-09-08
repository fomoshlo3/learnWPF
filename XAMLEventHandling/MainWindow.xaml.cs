using System.Windows;

namespace XAMLEventHandling
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

        private void Bold_Checked(object sender, RoutedEventArgs e)
        {
            txtBox1.FontWeight = FontWeights.Bold;
        }

        private void Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox1.FontWeight = FontWeights.Normal;
        }

        private void Italic_Checked(object sender, RoutedEventArgs e)
        {
            txtBox1.FontStyle = FontStyles.Italic;
        }

        private void Italic_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBox1.FontStyle = FontStyles.Normal;
        }

        private void IncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox1.FontSize < 18) txtBox1.FontSize += 2;
        }

        private void DecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox1.FontSize > 10) txtBox1.FontSize -= 2;
        }
    }
}
