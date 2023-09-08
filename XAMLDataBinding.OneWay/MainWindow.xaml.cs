using System.Windows;
using XAMLDataBinding.OneWay.Models;

namespace XAMLDataBinding.OneWay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Note: CodeBehind Style for binding DataContext
            DataContext = Employees.GetEmployees();
        }
    }
}
