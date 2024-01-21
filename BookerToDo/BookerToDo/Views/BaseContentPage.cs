using BookerToDo.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookerToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            NavBarBackButtonPressedAction = OnNavBarBackButtonPressed;
        }

        public Action NavBarBackButtonPressedAction { get; protected set; }

        protected override bool OnBackButtonPressed()
        {
            return OnBackPressed();
        }

        private void OnNavBarBackButtonPressed()
        {
            OnBackPressed();
        }

        private bool OnBackPressed()
        {
            bool result = false;

            if (BindingContext != null
                && BindingContext is BaseViewModel viewModel
                && viewModel.BackButtonPressedAction != null)
            {
                viewModel.BackButtonPressedAction.Invoke();
                result = true;
            }

            return result;
        }
    }
}
