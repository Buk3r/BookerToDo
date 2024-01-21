using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookerToDo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region -- Public properties --

        public Action BackButtonPressedAction { get; protected set; }

        #endregion

        #region -- INotifyPropertyChanged implementation --

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region -- Public methods --

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region -- Protected methods --

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        #endregion
    }
}
