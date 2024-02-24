using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.ViewModels
{
    public abstract class ViewModel : ObservableObject
    {
        public virtual void Dispose() { }
    }
}
