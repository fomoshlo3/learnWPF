using Microsoft.DataBindingSampleWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Microsoft.DataBindingSampleWpf.Resources
{
    public class ColorListDataContext : ObservableObject
    {
        public List<ColorDescriptor> LotsOfColors { get; private set; } //...the naming -.-

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

        }
    }
}
