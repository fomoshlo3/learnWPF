using Microsoft.DataBindingSampleWpf.Resources;
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
        //TODO: As an exercise, try hiding the entire Favorite Colors part of the UI when the FavoriteColors collection is empty.
        //Hint: use a StackPanel to group the affected controls, and bind the StackPanel's Visibility to a property in the ColorListDataContext class.
        //Whenever a favorite color is added or removed, notify the UI about the changes to this property.
    }
}
