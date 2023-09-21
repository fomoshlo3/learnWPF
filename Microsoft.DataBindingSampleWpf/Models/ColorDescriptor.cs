using Microsoft.DataBindingSampleWpf.ViewModels;
using System.Windows.Media;

namespace Microsoft.DataBindingSampleWpf.Models
{
    public class ColorDescriptor : ObservableObject
    {
        public Color Color { get; private set; }

        public string Name { get; private set; }

        public ColorDescriptor(Color color, string name)
        {
            Color = color;
            Name = name;
        }

        public override string ToString()
        {
            return $"#{Name} (#{Color.R:X2}{Color.G:X2}{Color.B:X2})";
        }
    }
}
