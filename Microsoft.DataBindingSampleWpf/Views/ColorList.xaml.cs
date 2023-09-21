using Microsoft.DataBindingSampleWpf.ViewModels;
using System.Windows;

namespace Microsoft.DataBindingSampleWpf.Views
{
    /// <summary>
    /// Interaction logic for ColorList.xaml
    /// </summary>
    public partial class ColorList : Window
    {
        private ColorListDataContext DC => (ColorListDataContext)DataContext;

        public ColorList()
        {
            InitializeComponent();
        }

        private void CmdAddToFavorites_Click(object sender, RoutedEventArgs e)
        {
            DC.AddSelectedColorToFavorites();
        }

        private void CmdRemoveFromFavorites_Click(object sender, RoutedEventArgs e)
        {
            DC.RemoveSelectedColorFromFavorites();
        }
    }
}
