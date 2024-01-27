using BookerToDo.Helpers;
using BookerToDo.Services.Dialog;
using BookerToDo.Services.Localization;
using BookerToDo.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookerToDo.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, INavigationAware
    {
        public BaseViewModel()
        {
            NavigationService = new NavigationService();
            DialogService = new DialogService();
            Translate = LocalizationService.GetInstance();
        }

        #region -- Public properties --

        public INavigationService NavigationService { get; }
        public IDialogService DialogService { get; }
        public ILocalizationService Translate { get; }
        public Action BackButtonPressedAction { get; protected set; }

        #endregion

        #region -- IInitialize implementation --

        public virtual void Initialize(IDictionary<string, object> parameters)
        {
        }

        public virtual Task InitializeAsync(IDictionary<string, object> parameters)
        {
            return Task.CompletedTask;
        }

        #endregion

        #region -- INavigationAware implementation --

        public virtual void OnNavigatedTo(IDictionary<string, object> parameters)
        {
        }

        public virtual Task OnNavigatedToAsync(IDictionary<string, object> parameters)
        {
            return Task.CompletedTask;
        }

        #endregion
    }
}
