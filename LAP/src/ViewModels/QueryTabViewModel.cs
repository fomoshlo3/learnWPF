using LAP.src.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.src.ViewModels
{
    public class QueryTabViewModel : ViewModel
    {


        public QueryTabViewModel(INavigationManager navigation)
        {
            Navigation = navigation;
        }

        #region Boilerplate
            #region Navigation
        private INavigationManager _navigation;
        public INavigationManager Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }


            #endregion


        #endregion
    }
}
