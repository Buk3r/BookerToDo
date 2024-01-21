using BookerToDo.Helpers;
using System;

namespace BookerToDo.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        #region -- Public properties --

        public Action BackButtonPressedAction { get; protected set; }

        #endregion
    }
}
