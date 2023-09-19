using Microsoft.DataBindingSampleWpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Microsoft.DataBindingSampleWpf.Resources
{
    public class ColorListDataContext : ObservableObject
    {
        public List<ColorDescriptor> LotsOfColors { get; private set; } //...the naming -.-

        /// <summary>
        /// Since a normal List doesn't notify the UI of it's changes, it is swapped with an ObservableCollection
        /// </summary>
        //public List<ColorDescriptor> FavoriteColors { get; } = new();
        public ObservableCollection<ColorDescriptor> FavoriteColors { get; } = new();

        //------------------------------------------------------
        //Note: again the standard pattern for Notifiying the UI
        private ColorDescriptor? _selectedColor;

        public ColorDescriptor? SelectedColor
        {
            //get { return _selectedColor; }
            get => _selectedColor;
            //set { _selectedColor = value; }
            set => Set(ref _selectedColor, value);
        }
        //------------------------------------------------------

        private ColorDescriptor _selectedFavoriteColor;

        public ColorDescriptor SelectedFavoriteColor
        {
            //get { return _selectedFavoriteColor; }
            get => _selectedFavoriteColor;
            //set { _selectedFavoriteColor = value; }
            set
            {
                Set(ref _selectedFavoriteColor, value);
                RaisePropertyChanged(nameof(IsRemoveFavoriteEnabled));
            }
        }

        //Forces the UI to query the SelectedFavoriteColor property and act accordingly.
        public bool IsRemoveFavoriteEnabled => SelectedFavoriteColor != null;


        public ColorListDataContext()
        {
            LotsOfColors = new List<ColorDescriptor>
            {
                new ColorDescriptor(Colors.Red, "red"),
                new ColorDescriptor(Colors.White, "white"),
                new ColorDescriptor(Colors.Green, "green"),
                new ColorDescriptor(Colors.Yellow, "yellow"),
                new ColorDescriptor(Colors.Blue, "blue"),
                new ColorDescriptor(Colors.Black, "black")
            };
            // Note: To make sure one can't add a Null entry to the favorites, the SelectedColor property is initialized with the first color
            // of the LotsOfColors list.
            SelectedColor = LotsOfColors[index: 0];
        }

        public void AddSelectedColorToFavorites()
        {
            if (SelectedColor == null) return;
            FavoriteColors.Add(SelectedColor);
            RaisePropertyChanged(nameof(IsNotEmptyList));
        }

        public void RemoveSelectedColorFromFavorites()
        {
            if (SelectedColor == null) return;
            FavoriteColors.Remove(SelectedFavoriteColor);
            RaisePropertyChanged(nameof(IsNotEmptyList));
        }


        /// <summary>
        /// Bool for controlling visibility of the FavoriteColorList
        /// </summary>
        public bool IsNotEmptyList => FavoriteColors.Count > 0;
    }
}
