using Microsoft.DataBindingSampleWpf.Resources;
using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Microsoft.DataBindingSampleWpf.Models
{
    public class Clock : ObservableObject /*INotifyPropertyChanged*/
    {
        /// <summary>
        /// Expression-bodied Member
        /// </summary>
        public string CurrentTime => DateTime.Now.ToLongTimeString();
        
        #region DEFAULT
        /* 
         * public string CurrentTime
         * {
         *      get 
         *      {
         *          return DateTime.Now.ToLongTimeString();
         *      }
         * }
         */
        #endregion

        /// <summary>
        /// By inheriting from INotifyPropertyChanged you implement this public event, this
        /// will be used to inform the GUI that the property of its bound DataSource has changed.
        /// </summary>
        //public event PropertyChangedEventHandler? PropertyChanged;

        private DispatcherTimer _timer;

        /// <summary>
        /// On Instantiating the _timer Property get's set and the PropertyChanged event 
        /// gets subscribed to the _timer.Tick and set to update CurrenTime.
        /// </summary>
        public Clock()
        {
            _timer = new DispatcherTimer 
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            //_timer.Tick += (sender, o) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTime)));
            _timer.Tick += (sender, o) => RaisePropertyChanged(nameof(CurrentTime));
            _timer.Start();
        }

    }
}
