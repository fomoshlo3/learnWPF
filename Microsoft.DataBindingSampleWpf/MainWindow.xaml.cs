using Microsoft.DataBindingSampleWpf.Resources;
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

namespace Microsoft.DataBindingSampleWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowDataContext DC => (MainWindowDataContext)DataContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Hello {DC.UserName}!");
            if (string.IsNullOrWhiteSpace(DC.UserName))
            {
                return;
            }

            DC.IsNameNeeded = false;
        }
    }
}
